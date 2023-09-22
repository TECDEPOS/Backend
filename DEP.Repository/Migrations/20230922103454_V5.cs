using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class V5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DKVisablity",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HRVisablity",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PKVisablity",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DKVisablity",
                table: "FileTags");

            migrationBuilder.DropColumn(
                name: "HRVisablity",
                table: "FileTags");

            migrationBuilder.DropColumn(
                name: "PKVisablity",
                table: "FileTags");
        }
    }
}
