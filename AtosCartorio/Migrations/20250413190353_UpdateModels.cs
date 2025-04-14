using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtosCartorio.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataObito",
                table: "Obitos",
                newName: "DataFalecimento");

            migrationBuilder.RenameColumn(
                name: "NomeRegistrado",
                table: "Nascimentos",
                newName: "NomeCompleto");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimentoPai",
                table: "Nascimentos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimentoMae",
                table: "Nascimentos",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LocalNascimento",
                table: "Nascimentos",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalNascimento",
                table: "Nascimentos");

            migrationBuilder.RenameColumn(
                name: "DataFalecimento",
                table: "Obitos",
                newName: "DataObito");

            migrationBuilder.RenameColumn(
                name: "NomeCompleto",
                table: "Nascimentos",
                newName: "NomeRegistrado");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimentoPai",
                table: "Nascimentos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimentoMae",
                table: "Nascimentos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }
    }
}
