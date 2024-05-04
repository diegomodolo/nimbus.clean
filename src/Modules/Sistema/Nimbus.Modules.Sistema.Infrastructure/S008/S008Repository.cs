// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="S008Repository.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the S008Repository.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Sistema.Infrastructure.S008;

using Nimbus.Common.Domain.Cadastros.Sistema;
using Nimbus.Modules.Infrastructure.Database;
using Nimbus.Modules.Sistema.Domain.S008;

internal sealed class S008Repository(NimbusDbContext context) : IS008Repository
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public Task<S008_Usuario?> BuscarAsync(string nomeUsuario, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc />
    public void Inserir(S008_Usuario entity)
    {
        context.S008_Usuario.Add(entity);
    }

    #endregion
}