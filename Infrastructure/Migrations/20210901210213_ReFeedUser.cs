using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ReFeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5e6ab61a-384d-47c3-a491-2da6332310da"),
                columns: new[] { "NormalizedUserName", "UserName" },
                values: new object[] { "ADMIN", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("5e6ab61a-384d-47c3-a491-2da6332310da"),
                columns: new[] { "NormalizedUserName", "UserName" },
                values: new object[] { "TESTUSER", "TestUser" });
        }
    }
}
