using Microsoft.EntityFrameworkCore.Migrations;

namespace CatalogAPI_DAL.Migrations
{
    public partial class alterCategoriesName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdCategory",
                table: "Categories",
                newName: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryID",
                table: "Categories",
                newName: "IdCategory");
        }
    }
}
