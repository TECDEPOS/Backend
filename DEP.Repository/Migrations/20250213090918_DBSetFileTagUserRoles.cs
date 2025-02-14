using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class DBSetFileTagUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileTagUserRole_FileTags_FileTagId",
                table: "FileTagUserRole");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileTagUserRole",
                table: "FileTagUserRole");

            migrationBuilder.RenameTable(
                name: "FileTagUserRole",
                newName: "FileTagUserRoles");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileTagUserRoles",
                table: "FileTagUserRoles",
                columns: new[] { "FileTagId", "Role" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 12, 10, 9, 17, 944, DateTimeKind.Local).AddTicks(9995), new byte[] { 173, 160, 61, 172, 225, 90, 86, 94, 41, 13, 28, 217, 159, 126, 46, 139, 191, 147, 198, 48, 113, 208, 213, 84, 138, 56, 128, 216, 141, 0, 119, 140, 65, 75, 165, 16, 215, 178, 113, 176, 9, 27, 88, 0, 207, 42, 155, 92, 55, 206, 38, 255, 97, 251, 126, 60, 83, 125, 152, 83, 108, 146, 153, 156 }, new byte[] { 214, 55, 144, 11, 188, 241, 29, 108, 168, 125, 59, 58, 233, 138, 4, 65, 163, 4, 90, 180, 250, 68, 79, 177, 17, 36, 44, 159, 57, 199, 247, 36, 205, 227, 44, 224, 74, 174, 180, 202, 224, 138, 159, 225, 54, 60, 192, 104, 73, 110, 80, 82, 255, 70, 238, 205, 66, 165, 134, 5, 114, 182, 204, 20, 46, 206, 37, 90, 176, 93, 191, 54, 226, 126, 157, 143, 22, 209, 179, 196, 183, 46, 115, 194, 102, 238, 2, 159, 102, 26, 150, 26, 68, 151, 134, 136, 107, 150, 236, 150, 38, 46, 144, 135, 41, 35, 50, 167, 14, 84, 156, 177, 75, 75, 85, 240, 252, 255, 30, 223, 110, 125, 97, 199, 182, 30, 93, 97 } });

            migrationBuilder.AddForeignKey(
                name: "FK_FileTagUserRoles_FileTags_FileTagId",
                table: "FileTagUserRoles",
                column: "FileTagId",
                principalTable: "FileTags",
                principalColumn: "FileTagId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileTagUserRoles_FileTags_FileTagId",
                table: "FileTagUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FileTagUserRoles",
                table: "FileTagUserRoles");

            migrationBuilder.RenameTable(
                name: "FileTagUserRoles",
                newName: "FileTagUserRole");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FileTagUserRole",
                table: "FileTagUserRole",
                columns: new[] { "FileTagId", "Role" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 12, 8, 37, 57, 516, DateTimeKind.Local).AddTicks(8343), new byte[] { 153, 160, 154, 166, 141, 39, 26, 33, 189, 241, 119, 193, 1, 93, 22, 79, 175, 179, 4, 170, 74, 181, 69, 155, 110, 38, 181, 179, 248, 106, 254, 45, 82, 17, 199, 216, 39, 207, 176, 136, 216, 188, 89, 252, 99, 189, 74, 92, 239, 237, 159, 212, 2, 192, 88, 212, 197, 151, 87, 196, 16, 16, 162, 135 }, new byte[] { 111, 25, 114, 156, 244, 213, 201, 148, 238, 64, 34, 153, 200, 112, 233, 241, 97, 47, 94, 243, 189, 251, 42, 123, 99, 34, 246, 46, 227, 213, 143, 168, 32, 210, 240, 202, 46, 234, 126, 83, 151, 167, 90, 9, 202, 22, 173, 83, 242, 201, 41, 63, 157, 218, 86, 18, 31, 246, 52, 144, 74, 164, 15, 129, 51, 186, 29, 148, 171, 7, 221, 58, 173, 136, 64, 110, 235, 151, 144, 92, 161, 98, 16, 211, 102, 194, 25, 230, 8, 123, 105, 236, 126, 209, 0, 27, 94, 211, 180, 39, 142, 171, 181, 182, 19, 192, 107, 183, 23, 161, 105, 13, 108, 64, 145, 103, 74, 59, 42, 219, 190, 248, 4, 5, 73, 112, 139, 199 } });

            migrationBuilder.AddForeignKey(
                name: "FK_FileTagUserRole_FileTags_FileTagId",
                table: "FileTagUserRole",
                column: "FileTagId",
                principalTable: "FileTags",
                principalColumn: "FileTagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
