// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IDomainEvent.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IDomainEvent.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Abstractions;

using MediatR;

public interface IDomainEvent : INotification
{
    #region Public Properties

    Guid Id { get; }

    DateTime OccurredOnUtc { get; }

    #endregion
}