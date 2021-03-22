using Microsoft.EntityFrameworkCore.Migrations;

namespace deep.wefood.api.Infrastructure.Migrations
{
    public partial class missedcompanyproperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StreetNumber",
                schema: "public",
                table: "companies",
                newName: "cmp_street_number");

            migrationBuilder.RenameColumn(
                name: "State",
                schema: "public",
                table: "companies",
                newName: "cmp_state");

            migrationBuilder.RenameColumn(
                name: "City",
                schema: "public",
                table: "companies",
                newName: "cmp_city");

            migrationBuilder.AlterColumn<string>(
                name: "cmp_state",
                schema: "public",
                table: "companies",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cmp_city",
                schema: "public",
                table: "companies",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "cmp_street_number",
                schema: "public",
                table: "companies",
                newName: "StreetNumber");

            migrationBuilder.RenameColumn(
                name: "cmp_state",
                schema: "public",
                table: "companies",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "cmp_city",
                schema: "public",
                table: "companies",
                newName: "City");

            migrationBuilder.AlterColumn<string>(
                name: "State",
                schema: "public",
                table: "companies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldDefaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                schema: "public",
                table: "companies",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
