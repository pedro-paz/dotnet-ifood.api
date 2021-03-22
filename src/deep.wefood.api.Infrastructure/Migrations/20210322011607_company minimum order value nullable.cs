using Microsoft.EntityFrameworkCore.Migrations;

namespace deep.wefood.api.Infrastructure.Migrations
{
    public partial class companyminimumordervaluenullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "cmp_min_order",
                schema: "public",
                table: "companies",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<float>(
                name: "cmp_min_order",
                schema: "public",
                table: "companies",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);
        }
    }
}
