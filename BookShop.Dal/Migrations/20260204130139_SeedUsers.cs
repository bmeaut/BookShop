using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BookShop.Dal.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "5610e8cb-6f66-4e89-ba44-3287259857a5", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "DisplayName", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "5610e8cb-6f66-4e89-ba44-3287259857a5", "Admin Aladár", "admin@example.com", true, false, null, "ADMIN@EXAMPLE.COM", "ADMIN@EXAMPLE.COM", "AQAAAAIAAYagAAAAEN+jQMxxcf6j/Qh5W23vp91R/ehaCa1xXEEqJuyAyHJvnRxOpK1COKRG/Tb0CdQCxg==", null, false, null, false, "admin@example.com" },
                    { 2, 0, "5610e8cb-6f66-4e89-ba44-3287259857a5", "Felhasználó Ferenc", "user@example.com", true, false, null, "USER@EXAMPLE.COM", "USER@EXAMPLE.COM", "AQAAAAIAAYagAAAAEN+jQMxxcf6j/Qh5W23vp91R/ehaCa1xXEEqJuyAyHJvnRxOpK1COKRG/Tb0CdQCxg==", null, false, null, false, "user@example.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "BookId", "CreatedDate", "Text", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTimeOffset(new DateTime(2026, 1, 2, 12, 22, 10, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Első komment a könyvhöz.", "Comment", 1 },
                    { 2, 1, new DateTimeOffset(new DateTime(2026, 1, 2, 16, 10, 3, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Második komment a könyvhöz.", "Comment", 2 },
                    { 3, 1, new DateTimeOffset(new DateTime(2026, 1, 3, 8, 47, 24, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Első review a könyvhöz.", "Review", 1 },
                    { 4, 1, new DateTimeOffset(new DateTime(2026, 1, 3, 17, 33, 54, 0, DateTimeKind.Unspecified), new TimeSpan(0, 1, 0, 0, 0)), "Második review a könyvhöz.", "Review", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
