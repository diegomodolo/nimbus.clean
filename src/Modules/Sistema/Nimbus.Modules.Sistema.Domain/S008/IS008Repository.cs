// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="IS008Repository.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the IS008Repository.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Domain.S008;

using Nimbus.Common.Domain.Cadastros.Sistema;

public interface IS008Repository
{
    #region Public Methods and Operators

    Task<S008_Usuario?> BuscarAsync(string nomeUsuario, CancellationToken cancellationToken = default);

    void Inserir(S008_Usuario entity);

    #endregion
}