using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ViasbilityUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PKVisablity",
                table: "FileTags",
                newName: "PKVisability");

            migrationBuilder.RenameColumn(
                name: "HRVisablity",
                table: "FileTags",
                newName: "HRVisability");

            migrationBuilder.RenameColumn(
                name: "DKVisablity",
                table: "FileTags",
                newName: "DKVisability");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PKVisability",
                table: "FileTags",
                newName: "PKVisablity");

            migrationBuilder.RenameColumn(
                name: "HRVisability",
                table: "FileTags",
                newName: "HRVisablity");

            migrationBuilder.RenameColumn(
                name: "DKVisability",
                table: "FileTags",
                newName: "DKVisablity");
        }
    }
}
