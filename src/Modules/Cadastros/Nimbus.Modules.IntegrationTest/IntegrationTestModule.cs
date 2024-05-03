// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IntegrationTestModule.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IntegrationTestModule.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.IntegrationTest;

using MassTransit;

public static class IntegrationTestModule
{
    #region Public Methods and Operators

    public static void ConfigureConsumers(IRegistrationConfigurator configurator)
    {
        configurator.AddConsumer<C001CriadaIntegrationEventConsumer>();
    }

    #endregion
}