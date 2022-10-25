using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hanc_Darius_Lab2.Migrations
{
    public partial class Author : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Bookcs");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Bookcs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookcs_AuthorID",
                table: "Bookcs",
                column: "AuthorID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookcs_Author_AuthorID",
                table: "Bookcs",
                column: "AuthorID",
                principalTable: "Author",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookcs_Author_AuthorID",
                table: "Bookcs");

            migrationBuilder.DropTable(
                name: "Author");

            migrationBuilder.DropIndex(
                name: "IX_Bookcs_AuthorID",
                table: "Bookcs");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Bookcs");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Bookcs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
