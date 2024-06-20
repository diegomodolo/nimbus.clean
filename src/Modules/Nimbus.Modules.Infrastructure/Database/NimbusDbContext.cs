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
using Microsoft.EntityFrameworkCore.Diagnostics;
using Nimbus.Common.Domain.Abstractions;
using Nimbus.Common.Domain.Cadastros.EstruturaOrganizacional.C001;
using Nimbus.Common.Domain.Cadastros.Sistema;
using Nimbus.Modules.Infrastructure.Database.Migrations.CompiledModel;

public sealed class NimbusDbContext : DbContext,
                                      IUnitOfWork
{
    #region Constructors and Destructors

    // public NimbusDbContext(DbContextOptions<NimbusDbContext> options)
    //     : base(options)
    // {
    // }

    public NimbusDbContext()
    {
    }

    #endregion

    #region Public Properties

    public DbSet<C001_Holding> C001_Holding { get; set; }

    public DbSet<S008_Usuario> S008_Usuario { get; set; }

    #endregion

    #region Methods

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.ConfigureWarnings(warn => warn.Ignore(CoreEventId.DetachedLazyLoadingWarning));
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                $"Data Source=192.168.0.8;Initial Catalog=NimbusDbProducaoGV;User Id=NimbusBaseUser;Pwd=Senha;MultipleActiveResultSets=True;Max Pool Size=300;Connection Timeout=0;TrustServerCertificate=true;");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        optionsBuilder.UseModel(NimbusDbContextModel.Instance);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);
        configurationBuilder.Conventions.Add(_ => new CustomFieldNameConvention());
    }

    /// <inheritdoc />
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    //     optionsBuilder.UseSqlServer("Server=.;Database=Nimbus;Trusted_Connection=True;");
    // }

    #endregion
}