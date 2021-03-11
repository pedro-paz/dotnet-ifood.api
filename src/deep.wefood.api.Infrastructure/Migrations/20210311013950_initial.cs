using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace deep.wefood.api.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "companies",
                schema: "public",
                columns: table => new
                {
                    cmp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cmp_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    cmp_name = table.Column<string>(type: "text", nullable: false),
                    cmp_address = table.Column<string>(type: "text", nullable: false),
                    cmp_dt_register = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_companies", x => x.cmp_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    user_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    user_name = table.Column<string>(type: "text", nullable: false),
                    user_email = table.Column<string>(type: "text", nullable: false),
                    user_password = table.Column<string>(type: "text", nullable: false),
                    user_dt_register = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "products",
                schema: "public",
                columns: table => new
                {
                    prod_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    prod_cmp_id = table.Column<int>(type: "integer", nullable: false),
                    prod_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    prod_name = table.Column<string>(type: "text", nullable: true),
                    prod_price = table.Column<decimal>(type: "numeric", nullable: false),
                    prod_desc = table.Column<string>(type: "text", nullable: true),
                    prod_discount = table.Column<decimal>(type: "numeric", nullable: true),
                    prod_dt_register = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.prod_id);
                    table.ForeignKey(
                        name: "FK_products_companies_prod_cmp_id",
                        column: x => x.prod_cmp_id,
                        principalSchema: "public",
                        principalTable: "companies",
                        principalColumn: "cmp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                schema: "public",
                columns: table => new
                {
                    ord_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ord_user_id = table.Column<int>(type: "integer", nullable: false),
                    ord_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ord_dt_register = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.ord_id);
                    table.ForeignKey(
                        name: "FK_orders_users_ord_user_id",
                        column: x => x.ord_user_id,
                        principalSchema: "public",
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "complements_group",
                schema: "public",
                columns: table => new
                {
                    cgroup_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cgroup_prod_id = table.Column<int>(type: "integer", nullable: false),
                    cgroup_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    cgroup_min = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0),
                    cgroup_max = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)10),
                    cgroup_dt_register = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complements_group", x => x.cgroup_id);
                    table.ForeignKey(
                        name: "FK_complements_group_products_cgroup_prod_id",
                        column: x => x.cgroup_prod_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_products",
                schema: "public",
                columns: table => new
                {
                    ordprod_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ordprod_ped_id = table.Column<int>(type: "integer", nullable: false),
                    ordprod_prod_id = table.Column<int>(type: "integer", nullable: false),
                    ordprod_price = table.Column<decimal>(type: "numeric", nullable: false),
                    ordprod_dt_register = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_products", x => x.ordprod_id);
                    table.ForeignKey(
                        name: "FK_order_products_orders_ordprod_ped_id",
                        column: x => x.ordprod_ped_id,
                        principalSchema: "public",
                        principalTable: "orders",
                        principalColumn: "ord_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_products_products_ordprod_prod_id",
                        column: x => x.ordprod_prod_id,
                        principalSchema: "public",
                        principalTable: "products",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "complement",
                schema: "public",
                columns: table => new
                {
                    compl_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    compl_cgroup_id = table.Column<int>(type: "integer", nullable: false),
                    compl_name = table.Column<string>(type: "text", nullable: false),
                    compl_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    compl_desc = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: true),
                    compl_dt_register = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_complement", x => x.compl_id);
                    table.ForeignKey(
                        name: "FK_complement_complements_group_compl_cgroup_id",
                        column: x => x.compl_cgroup_id,
                        principalSchema: "public",
                        principalTable: "complements_group",
                        principalColumn: "cgroup_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_complement_compl_cgroup_id",
                schema: "public",
                table: "complement",
                column: "compl_cgroup_id");

            migrationBuilder.CreateIndex(
                name: "IX_complements_group_cgroup_prod_id",
                schema: "public",
                table: "complements_group",
                column: "cgroup_prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_products_ordprod_ped_id",
                schema: "public",
                table: "order_products",
                column: "ordprod_ped_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_products_ordprod_prod_id",
                schema: "public",
                table: "order_products",
                column: "ordprod_prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_orders_ord_user_id",
                schema: "public",
                table: "orders",
                column: "ord_user_id");

            migrationBuilder.CreateIndex(
                name: "IX_products_prod_cmp_id",
                schema: "public",
                table: "products",
                column: "prod_cmp_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "complement",
                schema: "public");

            migrationBuilder.DropTable(
                name: "order_products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "complements_group",
                schema: "public");

            migrationBuilder.DropTable(
                name: "orders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "products",
                schema: "public");

            migrationBuilder.DropTable(
                name: "users",
                schema: "public");

            migrationBuilder.DropTable(
                name: "companies",
                schema: "public");
        }
    }
}
