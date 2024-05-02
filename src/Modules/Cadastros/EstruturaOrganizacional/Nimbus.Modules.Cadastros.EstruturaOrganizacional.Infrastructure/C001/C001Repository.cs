// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="C001Repository.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the C001Repository.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Cadastros.EstruturaOrganizacional.Infrastructure.C001;

using Microsoft.EntityFrameworkCore;
using Nimbus.Domain.Cadastros.EstruturaOrganizacional.C001;
using Nimbus.Modules.Cadastros.EstruturaOrganizacional.Domain.C001;
using Nimbus.Modules.Infrastructure.Database;

internal sealed class C001Repository(NimbusDbContext context) : IC001Repository
{
    #region Public Methods and Operators

    /// <inheritdoc />
    public async Task<C001_Holding?> BuscarAsync(string codigo, CancellationToken cancellationToken = default)
    {
        return await context.C001_Holding.FirstOrDefaultAsync(c => c.C001_Codigo == codigo, cancellationToken);
    }

    /// <inheritdoc />
    public void Insert(C001_Holding entity)
    {
        context.C001_Holding.Add(entity);
    }

    #endregion
}