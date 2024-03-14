using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApi.PartTwo.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineTypes_Engines_EngineId",
                table: "EngineTypes");

            migrationBuilder.DropIndex(
                name: "IX_EngineTypes_EngineId",
                table: "EngineTypes");

            migrationBuilder.DropColumn(
                name: "EngineId",
                table: "EngineTypes");

            migrationBuilder.AddColumn<int>(
                name: "EngineTypeId",
                table: "EngineTypes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "EngineTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "EngineTypeId",
                value: null);

            migrationBuilder.UpdateData(
                table: "EngineTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "EngineTypeId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_EngineTypes_EngineTypeId",
                table: "EngineTypes",
                column: "EngineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineTypes_Engines_EngineTypeId",
                table: "EngineTypes",
                column: "EngineTypeId",
                principalTable: "Engines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EngineTypes_Engines_EngineTypeId",
                table: "EngineTypes");

            migrationBuilder.DropIndex(
                name: "IX_EngineTypes_EngineTypeId",
                table: "EngineTypes");

            migrationBuilder.DropColumn(
                name: "EngineTypeId",
                table: "EngineTypes");

            migrationBuilder.AddColumn<int>(
                name: "EngineId",
                table: "EngineTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "EngineTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "EngineId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "EngineTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "EngineId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_EngineTypes_EngineId",
                table: "EngineTypes",
                column: "EngineId");

            migrationBuilder.AddForeignKey(
                name: "FK_EngineTypes_Engines_EngineId",
                table: "EngineTypes",
                column: "EngineId",
                principalTable: "Engines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
