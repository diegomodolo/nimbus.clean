// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IUnitOfWork.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IUnitOfWork.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Domain.Abstractions;

public interface IUnitOfWork
{
    #region Public Methods and Operators

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion
}