using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DEP.Repository.Migrations
{
    /// <inheritdoc />
    public partial class ExpandFiletagVisibility : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PKVisability",
                table: "FileTags",
                newName: "PKVisibility");

            migrationBuilder.RenameColumn(
                name: "HRVisability",
                table: "FileTags",
                newName: "HRVisibility");

            migrationBuilder.RenameColumn(
                name: "DKVisability",
                table: "FileTags",
                newName: "EducationLeaderVisibility");

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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 2, 22, 9, 47, 12, 491, DateTimeKind.Local).AddTicks(5035), new byte[] { 214, 198, 33, 25, 37, 176, 164, 56, 165, 204, 209, 28, 136, 41, 94, 19, 74, 137, 41, 126, 137, 32, 166, 90, 252, 167, 117, 183, 60, 44, 96, 84, 40, 211, 56, 100, 236, 2, 231, 153, 159, 55, 56, 22, 21, 106, 249, 19, 83, 242, 2, 179, 174, 215, 36, 217, 210, 243, 23, 41, 194, 173, 27, 105 }, new byte[] { 202, 8, 110, 196, 233, 89, 39, 118, 98, 136, 63, 75, 63, 217, 252, 151, 227, 94, 138, 89, 248, 244, 44, 53, 203, 79, 93, 83, 172, 37, 206, 47, 14, 224, 108, 140, 16, 99, 128, 110, 240, 53, 212, 134, 82, 152, 61, 151, 113, 241, 205, 91, 161, 50, 182, 152, 7, 18, 100, 8, 41, 58, 83, 234, 233, 141, 44, 13, 92, 254, 58, 114, 236, 0, 115, 63, 182, 223, 230, 140, 219, 31, 197, 233, 247, 105, 57, 107, 167, 131, 33, 153, 172, 156, 16, 156, 157, 190, 165, 97, 2, 138, 39, 255, 131, 88, 67, 200, 19, 139, 211, 153, 207, 82, 213, 63, 168, 223, 60, 90, 196, 166, 255, 142, 80, 32, 174, 230 } });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "PKVisibility",
                table: "FileTags",
                newName: "PKVisability");

            migrationBuilder.RenameColumn(
                name: "HRVisibility",
                table: "FileTags",
                newName: "HRVisability");

            migrationBuilder.RenameColumn(
                name: "EducationLeaderVisibility",
                table: "FileTags",
                newName: "DKVisability");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1,
                columns: new[] { "PasswordExpiryDate", "PasswordHash", "PasswordSalt" },
                values: new object[] { new DateTime(2024, 1, 25, 10, 14, 13, 473, DateTimeKind.Local).AddTicks(8209), new byte[] { 222, 63, 72, 110, 63, 9, 106, 34, 6, 71, 137, 79, 203, 196, 141, 6, 73, 193, 109, 36, 9, 230, 230, 156, 168, 116, 81, 195, 13, 70, 98, 16, 164, 226, 89, 171, 205, 47, 46, 241, 255, 73, 14, 59, 239, 82, 27, 204, 158, 47, 212, 141, 57, 229, 80, 69, 144, 52, 112, 183, 18, 169, 231, 182 }, new byte[] { 154, 114, 26, 207, 140, 147, 119, 181, 20, 29, 101, 150, 247, 252, 159, 193, 45, 78, 49, 93, 149, 64, 251, 17, 98, 56, 26, 136, 175, 18, 181, 143, 199, 107, 90, 39, 223, 45, 232, 89, 146, 223, 166, 78, 41, 180, 129, 96, 15, 134, 159, 247, 132, 48, 112, 223, 208, 69, 27, 219, 147, 125, 104, 238, 87, 52, 43, 42, 120, 250, 8, 47, 139, 202, 224, 144, 199, 145, 39, 230, 108, 88, 105, 139, 158, 119, 100, 212, 158, 109, 86, 133, 110, 21, 112, 186, 165, 217, 108, 24, 240, 235, 101, 174, 23, 250, 196, 216, 214, 107, 18, 111, 122, 218, 76, 215, 172, 51, 209, 212, 48, 87, 96, 68, 177, 17, 205, 45 } });
        }
    }
}
