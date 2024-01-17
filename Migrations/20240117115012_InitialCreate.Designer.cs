﻿// <auto-generated />
using System;
using LukeRamsayWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LukeRamsayWebApi.Migrations
{
    [DbContext(typeof(ECommerceContext))]
    [Migration("20240117115012_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LukeRamsayWebAPI.Models.Basket", b =>
                {
                    b.Property<int?>("BasketId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("BasketId"));

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("DiscountCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsCheckedOut")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BasketId");

                    b.HasIndex("CustomerId")
                        .IsUnique()
                        .HasFilter("[CustomerId] IS NOT NULL");

                    b.ToTable("Baskets");
                });

            modelBuilder.Entity("LukeRamsayWebAPI.Models.BasketItem", b =>
                {
                    b.Property<int?>("BasketItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("BasketItemId"));

                    b.Property<DateTime?>("AddedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("BasketId")
                        .HasColumnType("int");

                    b.Property<int?>("ProductId")
                        .HasColumnType("int");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BasketItemId");

                    b.HasIndex("BasketId");

                    b.HasIndex("ProductId");

                    b.ToTable("BasketItem");
                });

            modelBuilder.Entity("LukeRamsayWebAPI.Models.Customer", b =>
                {
                    b.Property<int?>("CustomerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("CustomerId"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("LukeRamsayWebAPI.Models.Product", b =>
                {
                    b.Property<int?>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("ProductId"));

                    b.Property<string>("Category")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Price")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ProductId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("LukeRamsayWebAPI.Models.Basket", b =>
                {
                    b.HasOne("LukeRamsayWebAPI.Models.Customer", "Customer")
                        .WithOne("Basket")
                        .HasForeignKey("LukeRamsayWebAPI.Models.Basket", "CustomerId");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("LukeRamsayWebAPI.Models.BasketItem", b =>
                {
                    b.HasOne("LukeRamsayWebAPI.Models.Basket", "Basket")
                        .WithMany("Items")
                        .HasForeignKey("BasketId");

                    b.HasOne("LukeRamsayWebAPI.Models.Product", "Product")
                        .WithMany("BasketItems")
                        .HasForeignKey("ProductId");

                    b.Navigation("Basket");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("LukeRamsayWebAPI.Models.Basket", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("LukeRamsayWebAPI.Models.Customer", b =>
                {
                    b.Navigation("Basket");
                });

            modelBuilder.Entity("LukeRamsayWebAPI.Models.Product", b =>
                {
                    b.Navigation("BasketItems");
                });
#pragma warning restore 612, 618
        }
    }
}