using Microsoft.EntityFrameworkCore.Migrations;

namespace deep.wefood.api.Infrastructure.Migrations
{
    public partial class complementgroupaddedcolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cgroup_name",
                schema: "public",
                table: "complements_group",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cgroup_name",
                schema: "public",
                table: "complements_group");
        }
    }
}
