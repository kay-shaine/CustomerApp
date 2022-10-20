﻿// <auto-generated />
using CustomerWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CustomerWebAPI.Migrations
{
    [DbContext(typeof(CustomerDbContext))]
    [Migration("20221013144100_initialMigration")]
    partial class initialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CustomerWebAPI.Entities.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<long>("PhoneNumber")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Customers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "kehinde.enigbokan@wemabank.com",
                            FirstName = "Kehinde",
                            ImageUrl = "/Images/Beauty/Beauty1.png",
                            LastName = "Enigbokan",
                            PhoneNumber = 7053201384L
                        },
                        new
                        {
                            Id = 2,
                            Email = "hasan.daranijo@wemabank.com",
                            FirstName = "Hassan",
                            ImageUrl = "/Images/Beauty/Beauty2.png",
                            LastName = "Daranijo",
                            PhoneNumber = 8168301935L
                        },
                        new
                        {
                            Id = 3,
                            Email = "tosin.peters@wemabank.com",
                            FirstName = "Tosin",
                            ImageUrl = "/Images/Beauty/Beauty3.png",
                            LastName = "Peters",
                            PhoneNumber = 8053518772L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}