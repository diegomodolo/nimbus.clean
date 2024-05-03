// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="EventBus.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the EventBus.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Infrastructure.EventBus;

using MassTransit;
using Nimbus.Common.Application.EventBus;

internal sealed class EventBus(IBus bus) : IEventBus
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task PublishAsync<T>(T integrationEvent, CancellationToken cancellationToken = default)
        where T : IIntegrationEvent
    {
        await bus.Publish(integrationEvent, cancellationToken);
    }

    #endregion
}