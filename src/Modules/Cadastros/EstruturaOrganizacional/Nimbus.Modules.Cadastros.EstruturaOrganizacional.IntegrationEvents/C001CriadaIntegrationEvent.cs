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
    public C001CriadaIntegrationEvent(Guid id, DateTime occurredOnUtc, C001_HoldingDto holding)
        : base(id, occurredOnUtc)
    {
        this.C001_HoldingDto = holding;
    }

    #endregion

    #region Public Properties

    public C001_HoldingDto C001_HoldingDto { get; init; }

    #endregion
}