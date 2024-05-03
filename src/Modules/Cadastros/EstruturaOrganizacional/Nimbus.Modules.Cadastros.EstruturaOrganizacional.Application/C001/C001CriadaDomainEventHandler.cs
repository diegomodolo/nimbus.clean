// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001CriadaDomainEventHandler.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001CriadaDomainEventHandler.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Application.C001;

using MediatR;
using Nimbus.Common.Application.EventBus;
using Nimbus.Common.Application.Exceptions;
using Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001;
using Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001.Events;
using Nimbus.Common.Domain.Messaging;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.IntegrationEvents;

internal sealed class C001CriadaDomainEventHandler(ISender sender, IEventBus eventBus) : IDomainEventHandler<C001CreatedDomainEvent>
{
    #region Implementation of INotificationHandler<in C001CreatedDomainEvent>

    /// <inheritdoc />
    public async Task Handle(C001CreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        var result = await sender.Send(new BuscarC001Query(notification.Codigo), cancellationToken);

        if (result.IsFailure)
        {
            throw new NimbusException(nameof(BuscarC001Query), result.Error);
        }

        await eventBus.PublishAsync(
            new C001CriadaIntegrationEvent(
                notification.Id,
                notification.OccurredOnUtc,
                new C001_HoldingDto
                    {
                        C001_Codigo = result.Value.C001_Codigo,
                        C001_Descricao = result.Value.C001_Descricao,
                        RegistroAtivo = result.Value.RegistroAtivo
                    }),
            cancellationToken);
    }

    #endregion
}