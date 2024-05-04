using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nimbus.Modules.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Cadastros");

            migrationBuilder.EnsureSchema(
                name: "Seguranca");

            migrationBuilder.CreateTable(
                name: "C001_Holding",
                schema: "Cadastros",
                columns: table => new
                {
                    C001_Codigo = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    C001_Descricao = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    RegistroAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_C001_Holding", x => x.C001_Codigo);
                });

            migrationBuilder.CreateTable(
                name: "S008_Usuario",
                schema: "Seguranca",
                columns: table => new
                {
                    S008_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    S008_IdProvedorAutenticacao = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    S008_Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EMail = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    RegistroAtivo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_S008_Usuario", x => x.S008_Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C001_Holding",
                schema: "Cadastros");

            migrationBuilder.DropTable(
                name: "S008_Usuario",
                schema: "Seguranca");
        }
    }
}
