using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class EducationLeaders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationBossId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "EducationBossId", "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { null, new DateTime(2024, 1, 23, 8, 13, 21, 804, DateTimeKind.Local).AddTicks(4343), new byte[] { 31, 138, 1, 51, 63, 36, 230, 151, 113, 150, 191, 185, 181, 221, 153, 57, 29, 184, 160, 76, 178, 223, 79, 65, 43, 209, 36, 215, 0, 10, 28, 109, 9, 27, 140, 160, 44, 240, 150, 194, 119, 25, 13, 169, 56, 62, 148, 197, 200, 32, 0, 32, 147, 253, 187, 143, 14, 216, 152, 203, 159, 25, 60, 230 }, new byte[] { 251, 1, 20, 57, 60, 234, 106, 66, 160, 119, 47, 151, 156, 120, 120, 208, 44, 48, 122, 50, 40, 49, 32, 46, 191, 92, 206, 22, 216, 236, 195, 45, 5, 212, 53, 133, 131, 191, 8, 97, 89, 26, 167, 83, 140, 136, 46, 81, 62, 62, 229, 171, 104, 168, 188, 101, 59, 99, 69, 248, 89, 228, 187, 61, 22, 142, 193, 179, 245, 130, 82, 53, 144, 162, 161, 220, 203, 20, 240, 147, 241, 24, 162, 100, 241, 71, 87, 111, 145, 70, 212, 107, 28, 4, 250, 208, 17, 153, 30, 155, 224, 47, 124, 54, 40, 146, 127, 169, 3, 204, 49, 57, 197, 17, 44, 167, 146, 93, 233, 178, 129, 41, 14, 203, 130, 153, 18, 186 } });

            migrationBuilder.CreateIndex(
                name: "IX_Users_EducationBossId",
                table: "Users",
                column: "EducationBossId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Users_EducationBossId",
                table: "Users",
                column: "EducationBossId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Users_EducationBossId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_EducationBossId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "EducationBossId",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 1, 16, 13, 44, 13, 241, DateTimeKind.Local).AddTicks(2249), new byte[] { 221, 53, 74, 241, 16, 21, 108, 229, 33, 43, 123, 121, 220, 230, 245, 170, 168, 2, 136, 110, 60, 255, 70, 56, 92, 3, 88, 225, 163, 82, 20, 199, 23, 246, 11, 245, 95, 196, 233, 64, 82, 159, 255, 129, 242, 255, 82, 148, 17, 129, 80, 219, 242, 214, 99, 232, 149, 66, 176, 186, 67, 58, 238, 15 }, new byte[] { 135, 26, 151, 211, 110, 51, 175, 63, 10, 87, 193, 154, 196, 91, 56, 168, 200, 76, 116, 125, 85, 226, 119, 182, 111, 174, 25, 227, 30, 179, 100, 254, 231, 179, 127, 218, 53, 214, 12, 249, 252, 198, 147, 74, 92, 103, 171, 120, 154, 148, 183, 61, 82, 187, 171, 64, 78, 108, 219, 13, 207, 134, 28, 103, 17, 185, 38, 74, 78, 65, 122, 193, 60, 126, 182, 15, 215, 231, 236, 28, 97, 35, 124, 26, 115, 234, 17, 43, 185, 109, 204, 68, 232, 57, 130, 247, 105, 39, 86, 141, 133, 129, 174, 214, 94, 204, 143, 90, 221, 233, 235, 105, 95, 191, 35, 144, 207, 116, 25, 232, 73, 69, 46, 34, 197, 230, 110, 159 } });
        }
    }
}
