// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="DomainEvent.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the DomainEvent.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Abstractions;

public abstract class DomainEvent : IDomainEvent
{
    #region Constructors and Destructors

    protected DomainEvent()
    {
            this.Id = Guid.NewGuid();
            this.OccurredOnUtc = DateTime.UtcNow;
        }

    protected DomainEvent(Guid id, DateTime occurredOnUtc)
    {
            this.Id = id;
            this.OccurredOnUtc = occurredOnUtc;
        }

    #endregion

    #region Public Properties

    /// <inheritdoc />
    public Guid Id { get; init; }

    /// <inheritdoc />
    public DateTime OccurredOnUtc { get; init; }

    #endregion
}