using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class addedudcationalLeadertoperson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EducationalLeaderId",
                table: "Persons",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 3, 18, 14, 24, 4, 356, DateTimeKind.Local).AddTicks(4379), new byte[] { 27, 100, 46, 77, 108, 108, 169, 48, 156, 43, 247, 137, 5, 155, 14, 36, 20, 214, 137, 15, 160, 245, 132, 196, 138, 144, 38, 249, 124, 187, 94, 161, 144, 103, 137, 86, 187, 109, 17, 228, 244, 37, 124, 174, 22, 142, 137, 213, 245, 188, 124, 199, 102, 149, 43, 142, 147, 102, 156, 243, 152, 117, 63, 166 }, new byte[] { 87, 6, 101, 58, 18, 198, 46, 62, 211, 113, 200, 172, 147, 171, 183, 82, 53, 162, 104, 131, 192, 92, 96, 20, 93, 163, 114, 23, 61, 232, 172, 56, 46, 225, 21, 88, 80, 109, 21, 201, 204, 95, 230, 180, 17, 252, 28, 67, 203, 11, 11, 26, 132, 148, 233, 251, 23, 123, 147, 49, 80, 60, 106, 6, 99, 66, 75, 86, 48, 129, 157, 144, 120, 202, 31, 220, 122, 232, 179, 41, 128, 132, 192, 162, 135, 125, 100, 124, 62, 31, 225, 128, 93, 226, 195, 49, 39, 144, 177, 180, 3, 145, 21, 153, 97, 218, 242, 6, 237, 72, 131, 148, 157, 176, 158, 251, 118, 243, 88, 156, 47, 122, 206, 67, 187, 254, 117, 73 } });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_EducationalLeaderId",
                table: "Persons",
                column: "EducationalLeaderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Users_EducationalLeaderId",
                table: "Persons",
                column: "EducationalLeaderId",
                principalTable: "Users",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Users_EducationalLeaderId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_EducationalLeaderId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "EducationalLeaderId",
                table: "Persons");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 4, 22, 216, DateTimeKind.Local).AddTicks(8037), new byte[] { 27, 180, 109, 187, 206, 12, 23, 186, 78, 91, 173, 222, 190, 217, 99, 27, 250, 52, 35, 140, 177, 30, 71, 23, 189, 49, 94, 112, 17, 114, 81, 250, 148, 18, 177, 4, 14, 227, 165, 58, 170, 165, 20, 128, 24, 181, 201, 57, 118, 111, 62, 252, 229, 183, 249, 238, 190, 50, 186, 118, 225, 103, 55, 57 }, new byte[] { 91, 159, 209, 166, 78, 217, 63, 95, 164, 224, 115, 168, 224, 190, 108, 240, 233, 68, 8, 5, 211, 91, 145, 226, 58, 81, 228, 165, 117, 230, 118, 168, 89, 207, 135, 37, 114, 148, 181, 243, 193, 64, 137, 79, 41, 173, 225, 125, 55, 46, 225, 132, 133, 193, 143, 135, 18, 241, 76, 84, 187, 178, 72, 108, 225, 119, 224, 52, 143, 10, 33, 111, 142, 205, 20, 169, 107, 212, 63, 66, 184, 145, 129, 116, 229, 18, 51, 101, 210, 220, 184, 201, 173, 42, 173, 87, 99, 154, 241, 21, 86, 70, 155, 153, 182, 229, 189, 226, 6, 70, 209, 230, 73, 165, 89, 155, 6, 119, 25, 246, 37, 164, 83, 72, 68, 5, 50, 192 } });
        }
    }
}
