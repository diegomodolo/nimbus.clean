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
            migrationBuilder.CreateTable(
                name: "C001_Holding",
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "C001_Holding");
        }
    }
}
