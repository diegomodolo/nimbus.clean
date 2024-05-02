// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="MigrationExtensions.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the MigrationExtensions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Api.Extensions;

using Microsoft.EntityFrameworkCore;
using Nimbus.Modules.Infrastructure.Database;

internal static class MigrationExtensions
{
    #region Methods

    private static void ApplyMigration<TDbContext>(IServiceScope scope)
        where TDbContext : DbContext
    {
        using TDbContext context = scope.ServiceProvider.GetRequiredService<TDbContext>();

        context.Database.Migrate();
    }

    internal static void ApplyMigrations(this IApplicationBuilder app)
    {
        using IServiceScope scope = app.ApplicationServices.CreateScope();

        ApplyMigration<NimbusDbContext>(scope);
    }

    #endregion
}