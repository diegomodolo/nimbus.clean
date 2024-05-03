// --------------------------------------------------------------------------------------------------------------------
//  <copyright file="NimbusDbContext.cs" company="Néctar Informática Ltda">
//    Nimbus
//  </copyright>
//  <summary>
//    Defines the NimbusDbContext.cs type.
//  </summary>
//  --------------------------------------------------------------------------------------------------------------------

namespace Nimbus.Modules.Infrastructure.Database;

using Microsoft.EntityFrameworkCore;
using Nimbus.Common.Domain.Abstractions;
using Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001;

public sealed class NimbusDbContext(DbContextOptions<NimbusDbContext> options) : DbContext(options),
    IUnitOfWork
{
    #region Public Properties

    public DbSet<C001_Holding> C001_Holding { get; set; }

    #endregion
}