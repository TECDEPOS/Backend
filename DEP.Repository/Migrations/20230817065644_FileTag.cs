using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FileTag : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "TimeProgram",
                table: "Modules",
                newName: "ModuleType");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "Files",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files",
                column: "FileTagId",
                principalTable: "FileTags",
                principalColumn: "FileTagId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "Files");

            migrationBuilder.RenameColumn(
                name: "ModuleType",
                table: "Modules",
                newName: "TimeProgram");

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files",
                column: "FileTagId",
                principalTable: "FileTags",
                principalColumn: "FileTagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
