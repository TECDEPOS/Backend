﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ICollectionToList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 12, 8, 37, 57, 516, DateTimeKind.Local).AddTicks(8343), new byte[] { 153, 160, 154, 166, 141, 39, 26, 33, 189, 241, 119, 193, 1, 93, 22, 79, 175, 179, 4, 170, 74, 181, 69, 155, 110, 38, 181, 179, 248, 106, 254, 45, 82, 17, 199, 216, 39, 207, 176, 136, 216, 188, 89, 252, 99, 189, 74, 92, 239, 237, 159, 212, 2, 192, 88, 212, 197, 151, 87, 196, 16, 16, 162, 135 }, new byte[] { 111, 25, 114, 156, 244, 213, 201, 148, 238, 64, 34, 153, 200, 112, 233, 241, 97, 47, 94, 243, 189, 251, 42, 123, 99, 34, 246, 46, 227, 213, 143, 168, 32, 210, 240, 202, 46, 234, 126, 83, 151, 167, 90, 9, 202, 22, 173, 83, 242, 201, 41, 63, 157, 218, 86, 18, 31, 246, 52, 144, 74, 164, 15, 129, 51, 186, 29, 148, 171, 7, 221, 58, 173, 136, 64, 110, 235, 151, 144, 92, 161, 98, 16, 211, 102, 194, 25, 230, 8, 123, 105, 236, 126, 209, 0, 27, 94, 211, 180, 39, 142, 171, 181, 182, 19, 192, 107, 183, 23, 161, 105, 13, 108, 64, 145, 103, 74, 59, 42, 219, 190, 248, 4, 5, 73, 112, 139, 199 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2025, 2, 11, 13, 42, 18, 608, DateTimeKind.Local).AddTicks(3129), new byte[] { 64, 67, 77, 33, 89, 81, 249, 94, 192, 112, 119, 195, 112, 163, 45, 162, 91, 6, 126, 116, 217, 148, 79, 114, 122, 254, 206, 99, 154, 79, 112, 73, 126, 136, 17, 64, 18, 195, 188, 151, 169, 246, 85, 116, 201, 23, 166, 146, 126, 81, 185, 29, 14, 42, 146, 62, 202, 102, 33, 209, 89, 112, 17, 246 }, new byte[] { 102, 27, 145, 136, 11, 92, 248, 116, 86, 19, 207, 137, 46, 57, 80, 169, 5, 91, 86, 43, 49, 249, 17, 10, 178, 43, 75, 116, 76, 200, 92, 55, 183, 172, 104, 80, 26, 13, 57, 227, 214, 152, 17, 104, 192, 175, 65, 190, 171, 106, 19, 217, 131, 70, 252, 114, 182, 11, 40, 197, 165, 36, 172, 195, 213, 182, 167, 65, 158, 200, 186, 109, 90, 106, 55, 249, 209, 34, 73, 167, 74, 245, 176, 208, 87, 17, 129, 151, 240, 204, 137, 39, 200, 214, 188, 220, 44, 125, 8, 33, 26, 182, 175, 31, 122, 191, 35, 81, 166, 29, 155, 190, 255, 14, 13, 248, 121, 92, 158, 151, 205, 218, 155, 159, 61, 191, 121, 166 } });
        }
    }
}
