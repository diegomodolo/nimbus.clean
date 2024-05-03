// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001CreatedDomainEvent.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001CreatedDomainEvent.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001.Events
{
    using Nimbus.Common.Domain.Abstractions;

    public sealed class C001CreatedDomainEvent(Guid eventId) : DomainEvent
    {
        #region Public Properties

        public Guid EventId { get; init; } = eventId;

        #endregion
    }
}