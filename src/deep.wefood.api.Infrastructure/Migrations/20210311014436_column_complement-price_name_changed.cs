using Microsoft.EntityFrameworkCore.Migrations;

namespace deep.wefood.api.Infrastructure.Migrations
{
    public partial class column_complementprice_name_changed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "public",
                table: "complement",
                newName: "coml_price");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "coml_price",
                schema: "public",
                table: "complement",
                newName: "Price");
        }
    }
}
