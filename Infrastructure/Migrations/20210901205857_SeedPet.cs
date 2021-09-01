using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class SeedPet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "BirthDay", "Name", "OwnerId", "Weight" },
                values: new object[] { new Guid("748d9d6e-3e8a-4e47-98d0-a3c24f1a56d9"), new DateTime(2020, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basya", new Guid("5e6ab61a-384d-47c3-a491-2da6332310da"), 2f });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: new Guid("748d9d6e-3e8a-4e47-98d0-a3c24f1a56d9"));
        }
    }
}
