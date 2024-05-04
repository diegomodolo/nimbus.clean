// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="SegurancaModule.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the SegurancaModule.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Infrastructure;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Nimbus.Modules.Sistema.Application.Abstractions.Identity;
using Nimbus.Modules.Sistema.Domain.S008;
using Nimbus.Modules.Sistema.Infrastructure.Identity;
using Nimbus.Modules.Sistema.Infrastructure.S008;

public static class SegurancaModule
{
    #region Public Methods and Operators

    public static IServiceCollection AddSegurancaModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IS008Repository, S008Repository>();

        services.AddScoped<IIdentityProviderService, IdentityProviderService>();

        services.AddInfrastructure(configuration);
        return services;
    }

    #endregion

    #region Methods

    private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<KeyCloakOptions>(configuration.GetSection("Sistema:KeyCloak"));

        services.AddTransient<KeyCloakAuthDelegatingHandler>();

        services.AddHttpClient<KeyCloakClient>(
                    (serviceProvider, httpClient) =>
                        {
                            var keyCloakOptions = serviceProvider.GetRequiredService<IOptions<KeyCloakOptions>>().Value;

                            httpClient.BaseAddress = new Uri(keyCloakOptions.AdminUrl);
                        })
                .AddHttpMessageHandler<KeyCloakAuthDelegatingHandler>();

        services.AddTransient<IIdentityProviderService, IdentityProviderService>();
    }

    #endregion
}