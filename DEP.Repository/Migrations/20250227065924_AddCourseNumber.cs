using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class AddCourseNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CourseNumber",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt", "RefreshTokenExpiryDate" },
                values: new object[] { new DateTime(2025, 2, 26, 7, 59, 24, 296, DateTimeKind.Local).AddTicks(1425), new byte[] { 193, 86, 249, 192, 205, 11, 162, 108, 87, 192, 221, 233, 29, 247, 222, 231, 212, 252, 169, 242, 187, 54, 134, 43, 227, 135, 192, 87, 252, 16, 99, 50, 42, 124, 227, 244, 144, 144, 157, 254, 47, 40, 196, 177, 202, 235, 33, 3, 79, 116, 143, 131, 149, 4, 102, 107, 128, 140, 157, 86, 190, 171, 204, 2 }, new byte[] { 132, 136, 67, 216, 103, 174, 219, 211, 215, 87, 191, 149, 179, 162, 131, 45, 99, 178, 150, 154, 174, 51, 234, 234, 129, 6, 159, 116, 247, 50, 102, 145, 144, 64, 0, 158, 78, 219, 47, 113, 90, 28, 37, 55, 122, 23, 167, 76, 226, 253, 16, 149, 35, 160, 186, 36, 42, 155, 7, 92, 226, 171, 143, 13, 221, 38, 32, 246, 60, 247, 202, 184, 203, 230, 71, 103, 73, 165, 163, 159, 238, 133, 159, 42, 150, 219, 229, 230, 60, 14, 146, 135, 98, 29, 32, 158, 14, 121, 62, 203, 64, 175, 65, 243, 246, 231, 70, 22, 119, 132, 169, 86, 83, 31, 189, 0, 144, 94, 85, 186, 167, 197, 245, 250, 230, 177, 226, 155 }, new DateTime(2025, 2, 28, 7, 59, 24, 296, DateTimeKind.Local).AddTicks(1457) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseNumber",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt", "RefreshTokenExpiryDate" },
                values: new object[] { new DateTime(2025, 2, 12, 10, 9, 17, 944, DateTimeKind.Local).AddTicks(9995), new byte[] { 173, 160, 61, 172, 225, 90, 86, 94, 41, 13, 28, 217, 159, 126, 46, 139, 191, 147, 198, 48, 113, 208, 213, 84, 138, 56, 128, 216, 141, 0, 119, 140, 65, 75, 165, 16, 215, 178, 113, 176, 9, 27, 88, 0, 207, 42, 155, 92, 55, 206, 38, 255, 97, 251, 126, 60, 83, 125, 152, 83, 108, 146, 153, 156 }, new byte[] { 214, 55, 144, 11, 188, 241, 29, 108, 168, 125, 59, 58, 233, 138, 4, 65, 163, 4, 90, 180, 250, 68, 79, 177, 17, 36, 44, 159, 57, 199, 247, 36, 205, 227, 44, 224, 74, 174, 180, 202, 224, 138, 159, 225, 54, 60, 192, 104, 73, 110, 80, 82, 255, 70, 238, 205, 66, 165, 134, 5, 114, 182, 204, 20, 46, 206, 37, 90, 176, 93, 191, 54, 226, 126, 157, 143, 22, 209, 179, 196, 183, 46, 115, 194, 102, 238, 2, 159, 102, 26, 150, 26, 68, 151, 134, 136, 107, 150, 236, 150, 38, 46, 144, 135, 41, 35, 50, 167, 14, 84, 156, 177, 75, 75, 85, 240, 252, 255, 30, 223, 110, 125, 97, 199, 182, 30, 93, 97 }, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
