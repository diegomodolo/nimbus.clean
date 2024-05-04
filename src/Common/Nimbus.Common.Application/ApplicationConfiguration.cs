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
using Nimbus.Common.Application.Behaviors;

public static class ApplicationConfiguration
{
    #region Public Methods and Operators

    public static IServiceCollection AddApplication(this IServiceCollection services, Assembly[] moduleAssemblies)
    {
        services.AddMediatR(
            config =>
                {
                    config.RegisterServicesFromAssemblies(moduleAssemblies);
                    config.AddOpenBehavior(typeof(ExceptionHandlingPipelineBehavior<,>));
                    config.AddOpenBehavior(typeof(RequestLoggingPipelineBehavior<,>));
                    config.AddOpenBehavior(typeof(ValidationPipelineBehavior<,>));
                });

        services.AddValidatorsFromAssemblies(moduleAssemblies, includeInternalTypes: true);

        return services;
    }

    #endregion
}