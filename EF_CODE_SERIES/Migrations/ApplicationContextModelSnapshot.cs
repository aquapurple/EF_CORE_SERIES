﻿// <auto-generated />
using System;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EF_CODE_SERIES.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entities.Student", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Student", (string)null);

                    b.HasData(
                        new
                        {
                            StudentId = new Guid("06cecb15-3357-4807-a510-216102e2560a"),
                            Age = 1,
                            Name = "Adrian"
                        },
                        new
                        {
                            StudentId = new Guid("ca1c3e28-1505-4fd7-be32-25032f02e2e0"),
                            Age = 40,
                            Name = "Anish"
                        },
                        new
                        {
                            StudentId = new Guid("2ddfcf0e-ddf7-4ed3-a004-7c494210e100"),
                            Age = 34,
                            Name = "Anu"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
