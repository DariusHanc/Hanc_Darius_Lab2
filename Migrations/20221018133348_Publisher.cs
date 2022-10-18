using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hanc_Darius_Lab2.Migrations
{
    public partial class Publisher : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PublisherID",
                table: "Bookcs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PublisherName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookcs_PublisherID",
                table: "Bookcs",
                column: "PublisherID");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookcs_Publisher_PublisherID",
                table: "Bookcs",
                column: "PublisherID",
                principalTable: "Publisher",
                principalColumn: "ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookcs_Publisher_PublisherID",
                table: "Bookcs");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropIndex(
                name: "IX_Bookcs_PublisherID",
                table: "Bookcs");

            migrationBuilder.DropColumn(
                name: "PublisherID",
                table: "Bookcs");
        }
    }
}
