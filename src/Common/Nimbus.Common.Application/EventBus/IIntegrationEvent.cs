// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IIntegrationEvent.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IIntegrationEvent.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Application.EventBus
{
    public interface IIntegrationEvent
    {
        #region Public Properties

        Guid Id { get; }

        DateTime OccurredOnUtc { get; }

        #endregion
    }
}