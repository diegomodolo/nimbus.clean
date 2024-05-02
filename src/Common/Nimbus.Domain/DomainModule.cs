// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DomainModule.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the DomainModule.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain;

using Microsoft.Extensions.DependencyInjection;

public static class DomainModule
{
    #region Public Methods and Operators

    public static IServiceCollection AddNimbusDomain(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(DomainModule).Assembly);

        return services;
    }

    #endregion
}