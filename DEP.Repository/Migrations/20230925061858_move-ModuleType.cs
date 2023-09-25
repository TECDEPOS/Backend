using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class moveModuleType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleType",
                table: "Modules");

            migrationBuilder.AddColumn<int>(
                name: "ModuleType",
                table: "PersonModules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModuleType",
                table: "PersonModules");

            migrationBuilder.AddColumn<int>(
                name: "ModuleType",
                table: "Modules",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
