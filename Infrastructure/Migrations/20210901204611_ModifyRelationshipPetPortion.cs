using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class ModifyRelationshipPetPortion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetPortion");

            migrationBuilder.AddColumn<Guid>(
                name: "PetId",
                table: "Portions",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Portions_PetId",
                table: "Portions",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Portions_Pets_PetId",
                table: "Portions",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Portions_Pets_PetId",
                table: "Portions");

            migrationBuilder.DropIndex(
                name: "IX_Portions_PetId",
                table: "Portions");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Portions");

            migrationBuilder.CreateTable(
                name: "PetPortion",
                columns: table => new
                {
                    PetsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PortionsId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetPortion", x => new { x.PetsId, x.PortionsId });
                    table.ForeignKey(
                        name: "FK_PetPortion_Pets_PetsId",
                        column: x => x.PetsId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetPortion_Portions_PortionsId",
                        column: x => x.PortionsId,
                        principalTable: "Portions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PetPortion_PortionsId",
                table: "PetPortion",
                column: "PortionsId");
        }
    }
}
