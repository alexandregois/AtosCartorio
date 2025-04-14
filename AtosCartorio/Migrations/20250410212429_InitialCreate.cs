using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtosCartorio.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Casamentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataCasamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Conjuge1_DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Conjuge1_Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge1_Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge1_NomePai = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge1_NomeMae = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge1_DataNascimentoPai = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Conjuge1_DataNascimentoMae = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Conjuge1_CpfPai = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge1_CpfMae = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge2_DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Conjuge2_Nome = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge2_Cpf = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge2_NomePai = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge2_NomeMae = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge2_DataNascimentoPai = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Conjuge2_DataNascimentoMae = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Conjuge2_CpfPai = table.Column<string>(type: "TEXT", nullable: false),
                    Conjuge2_CpfMae = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Casamentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Nascimentos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NomeRegistrado = table.Column<string>(type: "TEXT", nullable: false),
                    NomePai = table.Column<string>(type: "TEXT", nullable: false),
                    NomeMae = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimentoPai = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataNascimentoMae = table.Column<DateTime>(type: "TEXT", nullable: true),
                    CpfPai = table.Column<string>(type: "TEXT", nullable: false),
                    CpfMae = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nascimentos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Obitos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataRegistro = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataObito = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NomeFalecido = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    NomePai = table.Column<string>(type: "TEXT", nullable: false),
                    NomeMae = table.Column<string>(type: "TEXT", nullable: false),
                    DataNascimentoPai = table.Column<DateTime>(type: "TEXT", nullable: true),
                    DataNascimentoMae = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Obitos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Casamentos");

            migrationBuilder.DropTable(
                name: "Nascimentos");

            migrationBuilder.DropTable(
                name: "Obitos");
        }
    }
}
