using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShop.Dal.Migrations
{
    /// <inheritdoc />
    public partial class usersecuritystamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "SecurityStamp",
                value: "5610e8cb-6f66-4e89-ba44-3287259857a5");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "SecurityStamp",
                value: "5610e8cb-6f66-4e89-ba44-3287259857a5");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "SecurityStamp",
                value: null);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "SecurityStamp",
                value: null);
        }
    }
}
