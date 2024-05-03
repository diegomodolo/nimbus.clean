// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IEventBus.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IEventBus.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application.EventBus;

public interface IEventBus
{
    #region Public Methods and Operators

    Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
        where T : IIntegrationEvent;

    #endregion
}