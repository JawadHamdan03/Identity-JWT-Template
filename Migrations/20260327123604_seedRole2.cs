using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SecAndIdentity.Migrations
{
    /// <inheritdoc />
    public partial class seedRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6ca0bdf3-1b9d-4bbd-b814-cef753333297");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a1e1f0a5-9404-4742-81ab-2bb3a0c6703b");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "94f73640-e6ff-460b-8c3d-e245cc8cd47e", "3de3044f-103d-4381-921e-11ecbf8f0a1b", "User", "USER" },
                    { "bc03361d-e02c-4295-8017-b2bda82a1a40", "e9ca370d-e6b3-405a-b966-b820cdaa0e35", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "6ca0bdf3-1b9d-4bbd-b814-cef753333297", "905b95b7-c1c5-4981-a64d-5f033b515d0d", "User", "USER" },
                    { "a1e1f0a5-9404-4742-81ab-2bb3a0c6703b", "5c3ce178-a684-4c3e-95ad-e677a2976b5e", "Admin", "ADMIN" }
                });
        }
    }
}
