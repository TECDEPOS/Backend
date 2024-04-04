using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class databaseContextUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_EducationalLeaderId",
                table: "Persons");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 4, 1, 14, 38, 57, 380, DateTimeKind.Local).AddTicks(4087), new byte[] { 252, 99, 40, 247, 183, 57, 66, 42, 61, 21, 252, 64, 69, 230, 97, 50, 187, 92, 47, 254, 76, 6, 47, 112, 20, 192, 156, 255, 243, 3, 142, 172, 67, 173, 39, 249, 234, 34, 148, 55, 10, 56, 201, 31, 110, 27, 18, 252, 174, 53, 41, 130, 23, 99, 184, 42, 228, 246, 101, 111, 116, 247, 0, 63 }, new byte[] { 251, 77, 5, 47, 32, 6, 85, 104, 14, 94, 40, 49, 32, 40, 117, 99, 214, 89, 25, 22, 186, 8, 220, 247, 177, 22, 86, 3, 2, 54, 218, 246, 69, 35, 98, 238, 77, 98, 246, 103, 171, 193, 195, 226, 128, 72, 42, 48, 246, 154, 96, 45, 70, 51, 129, 97, 53, 103, 188, 199, 69, 213, 164, 178, 201, 227, 49, 19, 132, 105, 232, 138, 64, 167, 193, 204, 173, 118, 160, 182, 24, 157, 134, 142, 102, 248, 61, 170, 81, 236, 81, 206, 254, 162, 75, 182, 191, 15, 91, 43, 130, 167, 189, 127, 18, 67, 85, 76, 219, 255, 185, 92, 230, 255, 121, 130, 234, 30, 93, 255, 92, 31, 60, 23, 29, 135, 165, 46 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_EducationalLeaderId",
                table: "Persons",
                column: "EducationalLeaderId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_EducationalLeaderId",
                table: "Persons");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 3, 18, 14, 24, 4, 356, DateTimeKind.Local).AddTicks(4379), new byte[] { 27, 100, 46, 77, 108, 108, 169, 48, 156, 43, 247, 137, 5, 155, 14, 36, 20, 214, 137, 15, 160, 245, 132, 196, 138, 144, 38, 249, 124, 187, 94, 161, 144, 103, 137, 86, 187, 109, 17, 228, 244, 37, 124, 174, 22, 142, 137, 213, 245, 188, 124, 199, 102, 149, 43, 142, 147, 102, 156, 243, 152, 117, 63, 166 }, new byte[] { 87, 6, 101, 58, 18, 198, 46, 62, 211, 113, 200, 172, 147, 171, 183, 82, 53, 162, 104, 131, 192, 92, 96, 20, 93, 163, 114, 23, 61, 232, 172, 56, 46, 225, 21, 88, 80, 109, 21, 201, 204, 95, 230, 180, 17, 252, 28, 67, 203, 11, 11, 26, 132, 148, 233, 251, 23, 123, 147, 49, 80, 60, 106, 6, 99, 66, 75, 86, 48, 129, 157, 144, 120, 202, 31, 220, 122, 232, 179, 41, 128, 132, 192, 162, 135, 125, 100, 124, 62, 31, 225, 128, 93, 226, 195, 49, 39, 144, 177, 180, 3, 145, 21, 153, 97, 218, 242, 6, 237, 72, 131, 148, 157, 176, 158, 251, 118, 243, 88, 156, 47, 122, 206, 67, 187, 254, 117, 73 } });

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_EducationalLeaderId",
                table: "Persons",
                column: "EducationalLeaderId",
                principalTable: "Users",
                principalColumn: "UserId");
        }
    }
}
