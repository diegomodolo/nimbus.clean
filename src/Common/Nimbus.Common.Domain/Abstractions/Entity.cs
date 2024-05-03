// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Entity.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the Entity.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Common.Domain.Abstractions;

public abstract class Entity
{
    #region Fields

    private readonly List<IDomainEvent> _domainEvents = [];

    #endregion

    #region Constructors and Destructors

    protected Entity()
    {
    }

    #endregion

    #region Public Properties

    public IReadOnlyCollection<IDomainEvent> DomainEvents => this._domainEvents.ToList();

    public bool RegistroAtivo { get; set; }

    #endregion

    #region Public Methods and Operators

    public void ClearDomainEvents()
    {
        this._domainEvents.Clear();
    }

    #endregion

    #region Methods

    protected void Raise(IDomainEvent domainEvent)
    {
        this._domainEvents.Add(domainEvent);
    }

    #endregion
}