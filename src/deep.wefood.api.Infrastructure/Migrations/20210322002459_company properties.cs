using Microsoft.EntityFrameworkCore.Migrations;

namespace deep.wefood.api.Infrastructure.Migrations
{
    public partial class companyproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cmp_address",
                schema: "public",
                table: "companies",
                newName: "cmp_zip");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "public",
                table: "companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                schema: "public",
                table: "companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<short>(
                name: "StreetNumber",
                schema: "public",
                table: "companies",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<string>(
                name: "cmp_district",
                schema: "public",
                table: "companies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<float>(
                name: "cmp_min_order",
                schema: "public",
                table: "companies",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "cmp_rating",
                schema: "public",
                table: "companies",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "cmp_street",
                schema: "public",
                table: "companies",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                schema: "public",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "State",
                schema: "public",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "StreetNumber",
                schema: "public",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "cmp_district",
                schema: "public",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "cmp_min_order",
                schema: "public",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "cmp_rating",
                schema: "public",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "cmp_street",
                schema: "public",
                table: "companies");

            migrationBuilder.RenameColumn(
                name: "cmp_zip",
                schema: "public",
                table: "companies",
                newName: "cmp_address");
        }
    }
}
