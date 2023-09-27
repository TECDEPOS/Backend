using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class PersonModuleId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonModules",
                table: "PersonModules");

            migrationBuilder.AddColumn<int>(
                name: "PersonModuleId",
                table: "PersonModules",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonModules",
                table: "PersonModules",
                column: "PersonModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonModules_PersonId",
                table: "PersonModules",
                column: "PersonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonModules",
                table: "PersonModules");

            migrationBuilder.DropIndex(
                name: "IX_PersonModules_PersonId",
                table: "PersonModules");

            migrationBuilder.DropColumn(
                name: "PersonModuleId",
                table: "PersonModules");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonModules",
                table: "PersonModules",
                columns: new[] { "PersonId", "ModuleId", "StartDate" });
        }
    }
}
