// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IntegrationEvent.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IntegrationEvent.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application.EventBus
{
    public abstract class IntegrationEvent : IIntegrationEvent
    {
        #region Constructors and Destructors

        protected IntegrationEvent(Guid id, DateTime occurredOnUtc)
        {
            this.Id = id;
            this.OccurredOnUtc = occurredOnUtc;
        }

        #endregion

        #region Public Properties

        public Guid Id { get; init; }

        public DateTime OccurredOnUtc { get; init; }

        #endregion
    }
}