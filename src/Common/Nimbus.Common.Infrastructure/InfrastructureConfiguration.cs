// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="InfrastructureConfiguration.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the InfrastructureConfiguration.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Infrastructure;

using MassTransit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Nimbus.Common.Application.Caching;
using Nimbus.Common.Application.EventBus;
using Nimbus.Common.Infrastructure.Caching;
using StackExchange.Redis;

public static class InfrastructureConfiguration
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        Action<IRegistrationConfigurator>[] moduleConfigureConsumers,
        string databaseConnectionString,
        string redisConnectionString)
    {
        try
        {
            IConnectionMultiplexer connectionMultiplexer = ConnectionMultiplexer.Connect(redisConnectionString);
            services.TryAddSingleton(connectionMultiplexer);

            services.AddStackExchangeRedisCache(
                options => options.ConnectionMultiplexerFactory = () => Task.FromResult(connectionMultiplexer));
        }
        catch
        {
            services.AddDistributedMemoryCache();
        }

        services.TryAddSingleton<ICacheService, CacheService>();

        services.TryAddSingleton<IEventBus, EventBus.EventBus>();

        services.AddMassTransit(
            configure =>
                {
                    foreach (var configureConsumer in moduleConfigureConsumers)
                    {
                        configureConsumer(configure);
                    }

                    configure.SetKebabCaseEndpointNameFormatter();

                    configure.UsingInMemory(
                        (context, cfg) =>
                            {
                                cfg.ConfigureEndpoints(context);
                            });
                });

        return services;
    }
}