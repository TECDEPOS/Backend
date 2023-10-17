using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class defaultAdminUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Name", "PasswordExpiryDate", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryDate", "UserName", "UserRole" },
                values: new object[] { 1, "Administrator", new DateTime(2023, 10, 16, 8, 6, 55, 426, DateTimeKind.Local).AddTicks(192), new byte[] { 187, 223, 173, 90, 224, 0, 56, 7, 143, 88, 238, 73, 61, 254, 88, 102, 210, 26, 136, 148, 129, 128, 45, 130, 77, 98, 11, 119, 155, 197, 232, 64, 94, 87, 57, 173, 116, 120, 160, 189, 13, 138, 199, 40, 108, 169, 44, 95, 108, 217, 179, 7, 246, 92, 21, 7, 54, 69, 75, 106, 191, 198, 228, 90 }, new byte[] { 156, 80, 228, 74, 64, 32, 40, 177, 51, 3, 30, 101, 44, 14, 110, 140, 238, 248, 65, 217, 136, 0, 252, 245, 148, 222, 93, 136, 216, 52, 131, 34, 92, 130, 43, 158, 68, 76, 94, 195, 21, 87, 131, 128, 252, 81, 3, 231, 247, 34, 51, 8, 197, 143, 235, 14, 146, 164, 15, 131, 108, 226, 159, 249, 5, 4, 123, 105, 115, 167, 182, 88, 188, 117, 206, 39, 77, 254, 43, 210, 64, 208, 8, 156, 212, 175, 156, 110, 231, 194, 57, 8, 64, 248, 253, 210, 49, 133, 187, 81, 142, 56, 135, 208, 0, 165, 57, 114, 14, 174, 198, 167, 184, 185, 186, 152, 104, 45, 230, 112, 120, 32, 206, 105, 165, 159, 194, 71 }, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);
        }
    }
}
