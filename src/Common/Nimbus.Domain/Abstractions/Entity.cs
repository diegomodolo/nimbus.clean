// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="Entity.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the Entity.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Abstractions;

public abstract class Entity
{
    #region Public Properties

    public bool RegistroAtivo { get; set; }

    #endregion
}