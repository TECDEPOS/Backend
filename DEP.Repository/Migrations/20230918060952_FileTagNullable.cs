using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FileTagNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files");

            migrationBuilder.AlterColumn<int>(
                name: "FileTagId",
                table: "Files",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "FileTagId",
                table: "Files",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
