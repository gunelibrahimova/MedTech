using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class name : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_professions_ProfessionId",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_ProfessionId",
                table: "books");

            migrationBuilder.DropColumn(
                name: "ProfessionId",
                table: "books");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProfessionId",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_books_ProfessionId",
                table: "books",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_books_professions_ProfessionId",
                table: "books",
                column: "ProfessionId",
                principalTable: "professions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
