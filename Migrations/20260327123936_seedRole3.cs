using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecAndIdentity.Migrations
{
    /// <inheritdoc />
    public partial class seedRole3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94f73640-e6ff-460b-8c3d-e245cc8cd47e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc03361d-e02c-4295-8017-b2bda82a1a40");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "1", "Admin", "ADMIN" },
                    { "2", "2", "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94f73640-e6ff-460b-8c3d-e245cc8cd47e", "3de3044f-103d-4381-921e-11ecbf8f0a1b", "User", "USER" },
                    { "bc03361d-e02c-4295-8017-b2bda82a1a40", "e9ca370d-e6b3-405a-b966-b820cdaa0e35", "Admin", "ADMIN" }
                });
        }
    }
}
