// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Program.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the Program.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Nimbus.Api.Extensions;
using Nimbus.Api.Middleware;
using Nimbus.Common.Application;
using Nimbus.Common.Domain;
using Nimbus.Common.Infrastructure;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Infrastructure;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Presentation;
using Nimbus.Modules.Infrastructure;
using Nimbus.Modules.IntegrationTest;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => loggerConfig.ReadFrom.Configuration(context.Configuration));
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();

builder.Services.AddControllers().AddApplicationPart(AssemblyReference.Assembly).AddControllersAsServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Nimbus Common
builder.Services.AddNimbusDomain();

builder.Services.AddApplication(
    [
        Nimbus.Modules.Cadastros.EstruturaOrganizacional.Presentation.AssemblyReference.Assembly,
        Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.AssemblyReference.Assembly
    ]);

string databaseConnectionString = builder.Configuration.GetConnectionString("Database")!;
string redisConnectionString = builder.Configuration.GetConnectionString("Cache")!;

builder.Services.AddInfrastructure([IntegrationTestModule.ConfigureConsumers], databaseConnectionString, redisConnectionString);

// Nimbus Modules
builder.Services.AddCadastrosEstruturaOrganizacionalModule();
builder.Services.AddNimbusInfrastructureModule(builder.Configuration);

builder.Services.AddHealthChecks();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    app.ApplyMigrations();
}

app.MapHealthChecks(
    "health",
    new HealthCheckOptions
        {
            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        });

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSerilogRequestLogging();

app.UseExceptionHandler();

app.Run();