// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="AuthenticationExtensions.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the AuthenticationExtensions.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Infrastructure.Authentication;

using Microsoft.Extensions.DependencyInjection;

internal static class AuthenticationExtensions
{
    #region Methods

    internal static IServiceCollection AddAuthenticationInternal(this IServiceCollection services)
    {
        services.AddAuthorization();

        services.AddAuthentication().AddJwtBearer();

        services.AddHttpContextAccessor();

        services.ConfigureOptions<JwtBearerConfigureOptions>();

        return services;
    }

    #endregion
}