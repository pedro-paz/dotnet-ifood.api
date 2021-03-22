﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using deep.wefood.api.Infrastructure.Repositories;

namespace deep.wefood.api.Infrastructure.Migrations
{
    [DbContext(typeof(PostgresContext))]
    [Migration("20210322002459_company properties")]
    partial class companyproperties
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("public")
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cmp_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cmp_district");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("cmp_guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<float>("MinimumOrderValue")
                        .HasColumnType("real")
                        .HasColumnName("cmp_min_order");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cmp_name");

                    b.Property<float>("Rating")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("real")
                        .HasDefaultValue(0f)
                        .HasColumnName("cmp_rating");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("cmp_dt_register")
                        .HasDefaultValueSql("now()");

                    b.Property<string>("State")
                        .HasColumnType("text");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cmp_street");

                    b.Property<short>("StreetNumber")
                        .HasColumnType("smallint");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cmp_zip");

                    b.HasKey("Id");

                    b.ToTable("companies");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Complement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("compl_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("compl_desc");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("compl_guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("IdComplementGroup")
                        .HasColumnType("integer")
                        .HasColumnName("compl_cgroup_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("compl_name");

                    b.Property<decimal?>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("coml_price");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("compl_dt_register")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("IdComplementGroup");

                    b.ToTable("complement");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.ComplementGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("cgroup_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Guid")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("cgroup_guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int?>("IdProduct")
                        .IsRequired()
                        .HasColumnType("integer")
                        .HasColumnName("cgroup_prod_id");

                    b.Property<short>("Maximum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)10)
                        .HasColumnName("cgroup_max");

                    b.Property<short>("Minimum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("smallint")
                        .HasDefaultValue((short)0)
                        .HasColumnName("cgroup_min");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("cgroup_name");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("cgroup_dt_register")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("IdProduct");

                    b.ToTable("complements_group");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ord_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Guid")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("ord_guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("IdUser")
                        .HasColumnType("integer")
                        .HasColumnName("ord_user_id");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("ord_dt_register")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("IdUser");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("prod_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Description")
                        .HasColumnType("text")
                        .HasColumnName("prod_desc");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("prod_discount");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("prod_guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<int>("IdCompany")
                        .HasColumnType("integer")
                        .HasColumnName("prod_cmp_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("prod_name");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("prod_price");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("prod_dt_register")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("IdCompany");

                    b.ToTable("products");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.ProductOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ordprod_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<int>("IdOrder")
                        .HasColumnType("integer")
                        .HasColumnName("ordprod_ped_id");

                    b.Property<int>("IdProduct")
                        .HasColumnType("integer")
                        .HasColumnName("ordprod_prod_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("ordprod_price");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("ordprod_dt_register")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdProduct");

                    b.ToTable("order_products");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_email");

                    b.Property<string>("Guid")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasColumnName("user_guid")
                        .HasDefaultValueSql("uuid_generate_v4()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_password");

                    b.Property<DateTime>("RegisterDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("user_dt_register")
                        .HasDefaultValueSql("now()");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Complement", b =>
                {
                    b.HasOne("deep.wefood.api.Domain.Entities.ComplementGroup", null)
                        .WithMany("Complements")
                        .HasForeignKey("IdComplementGroup")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.ComplementGroup", b =>
                {
                    b.HasOne("deep.wefood.api.Domain.Entities.Product", null)
                        .WithMany("ComplementGroups")
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Order", b =>
                {
                    b.HasOne("deep.wefood.api.Domain.Entities.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("IdUser")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Product", b =>
                {
                    b.HasOne("deep.wefood.api.Domain.Entities.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("IdCompany")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.ProductOrder", b =>
                {
                    b.HasOne("deep.wefood.api.Domain.Entities.Order", "Order")
                        .WithMany("ProductOrder")
                        .HasForeignKey("IdOrder")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("deep.wefood.api.Domain.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("IdProduct")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Company", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.ComplementGroup", b =>
                {
                    b.Navigation("Complements");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Order", b =>
                {
                    b.Navigation("ProductOrder");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.Product", b =>
                {
                    b.Navigation("ComplementGroups");
                });

            modelBuilder.Entity("deep.wefood.api.Domain.Entities.User", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
