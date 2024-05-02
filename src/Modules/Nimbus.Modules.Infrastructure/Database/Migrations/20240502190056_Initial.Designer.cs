﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nimbus.Modules.Infrastructure.Database;

#nullable disable

namespace Nimbus.Modules.Infrastructure.Database.Migrations
{
    [DbContext(typeof(NimbusDbContext))]
    [Migration("20240502190056_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Nimbus.Domain.Cadastros.EstruturaOrganizacional.C001.C001_Holding", b =>
                {
                    b.Property<string>("C001_Codigo")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("C001_Descricao")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<bool>("RegistroAtivo")
                        .HasColumnType("bit");

                    b.HasKey("C001_Codigo");

                    b.ToTable("C001_Holding");
                });
#pragma warning restore 612, 618
        }
    }
}
