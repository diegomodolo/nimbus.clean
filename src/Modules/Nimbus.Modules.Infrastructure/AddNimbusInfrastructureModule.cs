// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AddNimbusInfrastructureModule.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the AddNimbusInfrastructureModule.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nimbus.Common.Domain.Abstractions;
using Nimbus.Common.Infrastructure.Interceptors;
using Nimbus.Modules.Infrastructure.Database;

public static class NimbusInfrastructureModule
{
    #region Public Methods and Operators

    public static IServiceCollection AddNimbusInfrastructureModule(
        this IServiceCollection services,
        IConfiguration configuration)

    {
        services.AddDbContext<NimbusDbContext>(
            (sp, options) =>
                {
                    var databaseConnectionString = configuration.GetConnectionString("Database");

                    options.UseSqlServer(databaseConnectionString)
                           .AddInterceptors(sp.GetRequiredService<PublishDomainEventsInterceptor>());
                });

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<NimbusDbContext>());

        return services;
    }

    #endregion
}