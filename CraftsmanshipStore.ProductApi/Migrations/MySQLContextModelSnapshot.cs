﻿// <auto-generated />
using System;
using CraftsmanshipStore.ProductApi.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CraftsmanshipStore.ProductApi.Migrations
{
    [DbContext(typeof(MySQLContext))]
    partial class MySQLContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CraftsmanshipStore.ProductApi.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)")
                        .HasColumnName("id");

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("category_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("varchar(1000)")
                        .HasColumnName("description");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("varchar(300)")
                        .HasColumnName("image_url");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("varchar(150)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)")
                        .HasColumnName("price");

                    b.HasKey("Id");

                    b.ToTable("product");

                    b.HasData(
                        new
                        {
                            Id = new Guid("369ae3a1-7cfa-494a-97a5-eb036419dfe4"),
                            CategoryName = "Painting",
                            Description = "Mountain Wood Wall Art, Painting Wood Wall Art, Vertical Wall Art, Wall Decor, Wood Wall Hanging, Housewarming Gift, Office Decor",
                            ImageUrl = "https://images.unsplash.com/photo-1640946756511-f5026d7614f9?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1074&q=80",
                            Name = "Mountain Wood Wall Art",
                            Price = 69.8m
                        },
                        new
                        {
                            Id = new Guid("b0242955-2e14-4110-938f-95dffdcb2da2"),
                            CategoryName = "Flower",
                            Description = "Glass Tube Vase/Flower Vase Pot/Unique Handmade Home Decor/Living Room Office Table Vase",
                            ImageUrl = "https://images.unsplash.com/photo-1444930694458-01babf71870c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=963&q=80",
                            Name = "Metal Wire Decorative",
                            Price = 147.85m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
