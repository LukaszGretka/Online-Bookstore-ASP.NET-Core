﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Products.API.Database;

namespace Products.API.Migrations
{
    [DbContext(typeof(ProductContext))]
    partial class ProductContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Products.API.Model.GraphicCard", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("BoostCoreFrequency")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Chipset")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int?>("CoreFrequency")
                        .IsRequired()
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Memory")
                        .HasColumnType("integer");

                    b.Property<int>("MemoryFrequency")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("numeric");

                    b.HasKey("ID");

                    b.HasIndex("ID")
                        .IsUnique();

                    b.ToTable("GraphicCards");
                });

            modelBuilder.Entity("Products.API.Model.Processor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal?>("Price")
                        .IsRequired()
                        .HasColumnType("numeric");

                    b.Property<string>("Producer")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Socket")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<float?>("StandardFrequency")
                        .IsRequired()
                        .HasColumnType("real");

                    b.Property<float?>("TurboFrequency")
                        .IsRequired()
                        .HasColumnType("real");

                    b.HasKey("ID");

                    b.HasIndex("ID")
                        .IsUnique();

                    b.ToTable("Processors");
                });
#pragma warning restore 612, 618
        }
    }
}
