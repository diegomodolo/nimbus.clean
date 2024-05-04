// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001CriadaIntegrationEvent.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001CriadaIntegrationEvent.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.IntegrationEvents;

using Nimbus.Common.Application.EventBus;
using Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001;

public sealed class C001CriadaIntegrationEvent : IntegrationEvent
{
    #region Constructors and Destructors

    /// <inheritdoc />
    public C001CriadaIntegrationEvent(Guid id, DateTime occurredOnUtc)
        : base(id, occurredOnUtc)
    {
    }

    #endregion
}