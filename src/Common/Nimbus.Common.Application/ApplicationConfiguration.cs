// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="ApplicationConfiguration.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the ApplicationConfiguration.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application;

using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

public static class ApplicationConfiguration
{
    #region Public Methods and Operators

    public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
    {
        services.AddMediatR(
            config =>
                {
                    config.RegisterServicesFromAssemblies(moduleAssemblies);

#pragma warning disable S125
                    // config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
#pragma warning restore S125
                    // config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
                    // config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                });

        services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

        return services;
    }

    #endregion
}