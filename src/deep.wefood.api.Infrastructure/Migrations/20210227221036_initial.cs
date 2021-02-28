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

            migrationBuilder.CreateTable(
                name: "clientes",
                schema: "public",
                columns: table => new
                {
                    cli_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    cli_nome = table.Column<string>(type: "text", nullable: false),
                    cli_email = table.Column<string>(type: "text", nullable: false),
                    cli_dt_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.cli_id);
                });

            migrationBuilder.CreateTable(
                name: "empresas",
                schema: "public",
                columns: table => new
                {
                    emp_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    emp_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    emp_nome = table.Column<string>(type: "text", nullable: false),
                    emp_dt_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_empresas", x => x.emp_id);
                });

            migrationBuilder.CreateTable(
                name: "pedidos",
                schema: "public",
                columns: table => new
                {
                    ped_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ped_cli_id = table.Column<int>(type: "integer", nullable: false),
                    ped_dt_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedidos", x => x.ped_id);
                    table.ForeignKey(
                        name: "FK_pedidos_clientes_ped_cli_id",
                        column: x => x.ped_cli_id,
                        principalSchema: "public",
                        principalTable: "clientes",
                        principalColumn: "cli_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                schema: "public",
                columns: table => new
                {
                    prod_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    prod_emp_id = table.Column<int>(type: "integer", nullable: false),
                    prod_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    prod_nome = table.Column<string>(type: "text", nullable: true),
                    prod_desc = table.Column<string>(type: "text", nullable: true),
                    prod_dt_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.prod_id);
                    table.ForeignKey(
                        name: "FK_produtos_empresas_prod_emp_id",
                        column: x => x.prod_emp_id,
                        principalSchema: "public",
                        principalTable: "empresas",
                        principalColumn: "emp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "public",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    user_emp_id = table.Column<int>(type: "integer", nullable: false),
                    user_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    user_nome = table.Column<string>(type: "text", nullable: false),
                    user_email = table.Column<string>(type: "text", nullable: false),
                    user_senha = table.Column<string>(type: "text", nullable: false),
                    user_dt_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_usuarios_empresas_user_emp_id",
                        column: x => x.user_emp_id,
                        principalSchema: "public",
                        principalTable: "empresas",
                        principalColumn: "emp_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ingredientes",
                schema: "public",
                columns: table => new
                {
                    ing_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    ing_emp_id = table.Column<int>(type: "integer", nullable: false),
                    IdProduto = table.Column<int>(type: "integer", nullable: false),
                    ing_nome = table.Column<string>(type: "text", nullable: false),
                    ing_guid = table.Column<string>(type: "text", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    ing_desc = table.Column<string>(type: "text", nullable: false),
                    ing_dt_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredientes", x => x.ing_id);
                    table.ForeignKey(
                        name: "FK_ingredientes_empresas_ing_emp_id",
                        column: x => x.ing_emp_id,
                        principalSchema: "public",
                        principalTable: "empresas",
                        principalColumn: "emp_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ingredientes_produtos_IdProduto",
                        column: x => x.IdProduto,
                        principalSchema: "public",
                        principalTable: "produtos",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "pedido_produtos",
                schema: "public",
                columns: table => new
                {
                    pedprod_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    pedprod_ped_id = table.Column<int>(type: "integer", nullable: false),
                    pedprod_prod_id = table.Column<int>(type: "integer", nullable: false),
                    pedprod_dt_cadastro = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pedido_produtos", x => x.pedprod_id);
                    table.ForeignKey(
                        name: "FK_pedido_produtos_pedidos_pedprod_ped_id",
                        column: x => x.pedprod_ped_id,
                        principalSchema: "public",
                        principalTable: "pedidos",
                        principalColumn: "ped_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_pedido_produtos_produtos_pedprod_prod_id",
                        column: x => x.pedprod_prod_id,
                        principalSchema: "public",
                        principalTable: "produtos",
                        principalColumn: "prod_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ingredientes_IdProduto",
                schema: "public",
                table: "ingredientes",
                column: "IdProduto");

            migrationBuilder.CreateIndex(
                name: "IX_ingredientes_ing_emp_id",
                schema: "public",
                table: "ingredientes",
                column: "ing_emp_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_produtos_pedprod_ped_id",
                schema: "public",
                table: "pedido_produtos",
                column: "pedprod_ped_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedido_produtos_pedprod_prod_id",
                schema: "public",
                table: "pedido_produtos",
                column: "pedprod_prod_id");

            migrationBuilder.CreateIndex(
                name: "IX_pedidos_ped_cli_id",
                schema: "public",
                table: "pedidos",
                column: "ped_cli_id");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_prod_emp_id",
                schema: "public",
                table: "produtos",
                column: "prod_emp_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_user_emp_id",
                schema: "public",
                table: "usuarios",
                column: "user_emp_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ingredientes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pedido_produtos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "public");

            migrationBuilder.DropTable(
                name: "pedidos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "produtos",
                schema: "public");

            migrationBuilder.DropTable(
                name: "clientes",
                schema: "public");

            migrationBuilder.DropTable(
                name: "empresas",
                schema: "public");
        }
    }
}
