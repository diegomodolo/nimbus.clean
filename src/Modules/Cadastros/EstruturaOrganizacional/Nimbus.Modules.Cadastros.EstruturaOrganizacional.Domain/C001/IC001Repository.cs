// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IC001Repository.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IC001Repository.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Domain.C001;

using Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001;

public interface IC001Repository
{
    #region Public Methods and Operators

    Task<C001_Holding?> BuscarAsync(string codigo, CancellationToken cancellationToken = default);

    void Insert(C001_Holding entity);

    #endregion
}