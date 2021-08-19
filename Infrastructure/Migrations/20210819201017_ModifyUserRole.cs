using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ModifyUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Portions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "UserId1",
                table: "Portions",
                type: "varbinary(16)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "AspNetRoles",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Portions_UserId1",
                table: "Portions",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Portions_AspNetUsers_UserId1",
                table: "Portions",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portions_AspNetUsers_UserId1",
                table: "Portions");

            migrationBuilder.DropIndex(
                name: "IX_Portions_UserId1",
                table: "Portions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Portions");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Portions");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "AspNetRoles");
        }
    }
}
