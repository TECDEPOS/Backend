using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddFileTagUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ControllerVisibility",
                table: "FileTags");

            migrationBuilder.DropColumn(
                name: "DKVisibility",
                table: "FileTags");

            migrationBuilder.DropColumn(
                name: "EducationBossVisibility",
                table: "FileTags");

            migrationBuilder.DropColumn(
                name: "EducationLeaderVisibility",
                table: "FileTags");

            migrationBuilder.DropColumn(
                name: "HRVisibility",
                table: "FileTags");

            migrationBuilder.DropColumn(
                name: "PKVisibility",
                table: "FileTags");

            migrationBuilder.CreateTable(
                name: "FileTagUserRole",
                columns: table => new
                {
                    FileTagId = table.Column<int>(type: "int", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileTagUserRole", x => new { x.FileTagId, x.Role });
                    table.ForeignKey(
                        name: "FK_FileTagUserRole_FileTags_FileTagId",
                        column: x => x.FileTagId,
                        principalTable: "FileTags",
                        principalColumn: "FileTagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 11, 13, 42, 18, 608, DateTimeKind.Local).AddTicks(3129), new byte[] { 64, 67, 77, 33, 89, 81, 249, 94, 192, 112, 119, 195, 112, 163, 45, 162, 91, 6, 126, 116, 217, 148, 79, 114, 122, 254, 206, 99, 154, 79, 112, 73, 126, 136, 17, 64, 18, 195, 188, 151, 169, 246, 85, 116, 201, 23, 166, 146, 126, 81, 185, 29, 14, 42, 146, 62, 202, 102, 33, 209, 89, 112, 17, 246 }, new byte[] { 102, 27, 145, 136, 11, 92, 248, 116, 86, 19, 207, 137, 46, 57, 80, 169, 5, 91, 86, 43, 49, 249, 17, 10, 178, 43, 75, 116, 76, 200, 92, 55, 183, 172, 104, 80, 26, 13, 57, 227, 214, 152, 17, 104, 192, 175, 65, 190, 171, 106, 19, 217, 131, 70, 252, 114, 182, 11, 40, 197, 165, 36, 172, 195, 213, 182, 167, 65, 158, 200, 186, 109, 90, 106, 55, 249, 209, 34, 73, 167, 74, 245, 176, 208, 87, 17, 129, 151, 240, 204, 137, 39, 200, 214, 188, 220, 44, 125, 8, 33, 26, 182, 175, 31, 122, 191, 35, 81, 166, 29, 155, 190, 255, 14, 13, 248, 121, 92, 158, 151, 205, 218, 155, 159, 61, 191, 121, 166 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileTagUserRole");

            migrationBuilder.AddColumn<bool>(
                name: "ControllerVisibility",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "DKVisibility",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EducationBossVisibility",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "EducationLeaderVisibility",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HRVisibility",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "PKVisibility",
                table: "FileTags",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 4, 1, 14, 38, 57, 380, DateTimeKind.Local).AddTicks(4087), new byte[] { 252, 99, 40, 247, 183, 57, 66, 42, 61, 21, 252, 64, 69, 230, 97, 50, 187, 92, 47, 254, 76, 6, 47, 112, 20, 192, 156, 255, 243, 3, 142, 172, 67, 173, 39, 249, 234, 34, 148, 55, 10, 56, 201, 31, 110, 27, 18, 252, 174, 53, 41, 130, 23, 99, 184, 42, 228, 246, 101, 111, 116, 247, 0, 63 }, new byte[] { 251, 77, 5, 47, 32, 6, 85, 104, 14, 94, 40, 49, 32, 40, 117, 99, 214, 89, 25, 22, 186, 8, 220, 247, 177, 22, 86, 3, 2, 54, 218, 246, 69, 35, 98, 238, 77, 98, 246, 103, 171, 193, 195, 226, 128, 72, 42, 48, 246, 154, 96, 45, 70, 51, 129, 97, 53, 103, 188, 199, 69, 213, 164, 178, 201, 227, 49, 19, 132, 105, 232, 138, 64, 167, 193, 204, 173, 118, 160, 182, 24, 157, 134, 142, 102, 248, 61, 170, 81, 236, 81, 206, 254, 162, 75, 182, 191, 15, 91, 43, 130, 167, 189, 127, 18, 67, 85, 76, 219, 255, 185, 92, 230, 255, 121, 130, 234, 30, 93, 255, 92, 31, 60, 23, 29, 135, 165, 46 } });
        }
    }
}
