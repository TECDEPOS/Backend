using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class FileTagIdSetNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 4, 22, 216, DateTimeKind.Local).AddTicks(8037), new byte[] { 27, 180, 109, 187, 206, 12, 23, 186, 78, 91, 173, 222, 190, 217, 99, 27, 250, 52, 35, 140, 177, 30, 71, 23, 189, 49, 94, 112, 17, 114, 81, 250, 148, 18, 177, 4, 14, 227, 165, 58, 170, 165, 20, 128, 24, 181, 201, 57, 118, 111, 62, 252, 229, 183, 249, 238, 190, 50, 186, 118, 225, 103, 55, 57 }, new byte[] { 91, 159, 209, 166, 78, 217, 63, 95, 164, 224, 115, 168, 224, 190, 108, 240, 233, 68, 8, 5, 211, 91, 145, 226, 58, 81, 228, 165, 117, 230, 118, 168, 89, 207, 135, 37, 114, 148, 181, 243, 193, 64, 137, 79, 41, 173, 225, 125, 55, 46, 225, 132, 133, 193, 143, 135, 18, 241, 76, 84, 187, 178, 72, 108, 225, 119, 224, 52, 143, 10, 33, 111, 142, 205, 20, 169, 107, 212, 63, 66, 184, 145, 129, 116, 229, 18, 51, 101, 210, 220, 184, 201, 173, 42, 173, 87, 99, 154, 241, 21, 86, 70, 155, 153, 182, 229, 189, 226, 6, 70, 209, 230, 73, 165, 89, 155, 6, 119, 25, 246, 37, 164, 83, 72, 68, 5, 50, 192 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files",
                column: "FileTagId",
                principalTable: "FileTags",
                principalColumn: "FileTagId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 2, 22, 9, 47, 12, 491, DateTimeKind.Local).AddTicks(5035), new byte[] { 214, 198, 33, 25, 37, 176, 164, 56, 165, 204, 209, 28, 136, 41, 94, 19, 74, 137, 41, 126, 137, 32, 166, 90, 252, 167, 117, 183, 60, 44, 96, 84, 40, 211, 56, 100, 236, 2, 231, 153, 159, 55, 56, 22, 21, 106, 249, 19, 83, 242, 2, 179, 174, 215, 36, 217, 210, 243, 23, 41, 194, 173, 27, 105 }, new byte[] { 202, 8, 110, 196, 233, 89, 39, 118, 98, 136, 63, 75, 63, 217, 252, 151, 227, 94, 138, 89, 248, 244, 44, 53, 203, 79, 93, 83, 172, 37, 206, 47, 14, 224, 108, 140, 16, 99, 128, 110, 240, 53, 212, 134, 82, 152, 61, 151, 113, 241, 205, 91, 161, 50, 182, 152, 7, 18, 100, 8, 41, 58, 83, 234, 233, 141, 44, 13, 92, 254, 58, 114, 236, 0, 115, 63, 182, 223, 230, 140, 219, 31, 197, 233, 247, 105, 57, 107, 167, 131, 33, 153, 172, 156, 16, 156, 157, 190, 165, 97, 2, 138, 39, 255, 131, 88, 67, 200, 19, 139, 211, 153, 207, 82, 213, 63, 168, 223, 60, 90, 196, 166, 255, 142, 80, 32, 174, 230 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Files_FileTags_FileTagId",
                table: "Files",
                column: "FileTagId",
                principalTable: "FileTags",
                principalColumn: "FileTagId");
        }
    }
}
