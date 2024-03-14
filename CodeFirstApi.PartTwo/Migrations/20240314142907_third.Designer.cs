﻿// <auto-generated />
using System;
using CodeFirstApi.PartTwo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CodeFirstApi.PartTwo.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240314142907_third")]
    partial class third
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CodeFirstApi.PartTwo.Model.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChasisNumber")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EngineId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EngineId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "Zastava",
                            ChasisNumber = 1992,
                            Color = "red",
                            EngineId = 1,
                            Model = "Yugo",
                            Year = 1980
                        },
                        new
                        {
                            Id = 2,
                            Brand = "Zastava",
                            ChasisNumber = 1992,
                            Color = "red",
                            EngineId = 2,
                            Model = "Yugo",
                            Year = 1980
                        });
                });

            modelBuilder.Entity("CodeFirstApi.PartTwo.Model.Engine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SerialNumber")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Engines");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Brand = "E115",
                            SerialNumber = 1992,
                            Year = 1980
                        },
                        new
                        {
                            Id = 2,
                            Brand = "F1215",
                            SerialNumber = 1992,
                            Year = 1980
                        });
                });

            modelBuilder.Entity("CodeFirstApi.PartTwo.Model.EngineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EngineTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EngineTypeId");

                    b.ToTable("EngineTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Model = "O1215",
                            Name = "O1123"
                        },
                        new
                        {
                            Id = 2,
                            Model = "F1215",
                            Name = "F1123"
                        });
                });

            modelBuilder.Entity("CodeFirstApi.PartTwo.Model.Car", b =>
                {
                    b.HasOne("CodeFirstApi.PartTwo.Model.Engine", "Engine")
                        .WithMany()
                        .HasForeignKey("EngineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Engine");
                });

            modelBuilder.Entity("CodeFirstApi.PartTwo.Model.EngineType", b =>
                {
                    b.HasOne("CodeFirstApi.PartTwo.Model.Engine", "Engine")
                        .WithMany("EngineTypes")
                        .HasForeignKey("EngineTypeId");

                    b.Navigation("Engine");
                });

            modelBuilder.Entity("CodeFirstApi.PartTwo.Model.Engine", b =>
                {
                    b.Navigation("EngineTypes");
                });
#pragma warning restore 612, 618
        }
    }
}
