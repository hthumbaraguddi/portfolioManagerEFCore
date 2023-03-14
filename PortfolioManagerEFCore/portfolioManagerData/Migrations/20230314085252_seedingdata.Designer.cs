﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using portfolioManagerData;

#nullable disable

namespace portfolioManagerData.Migrations
{
    [DbContext(typeof(PortfolioDataContext))]
    [Migration("20230314085252_seedingdata")]
    partial class seedingdata
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("portfolioManagerDomain.Equity", b =>
                {
                    b.Property<int>("EquityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EquityId"), 1L, 1);

                    b.Property<double>("AcquiredPrice")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("OverallPnL")
                        .HasColumnType("float");

                    b.Property<int>("PortfolioID")
                        .HasColumnType("int");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("datetime2");

                    b.Property<double?>("SoldPrice")
                        .HasColumnType("float");

                    b.Property<bool>("isSold")
                        .HasColumnType("bit");

                    b.HasKey("EquityId");

                    b.HasIndex("PortfolioID");

                    b.ToTable("Equity");

                    b.HasData(
                        new
                        {
                            EquityId = 1,
                            AcquiredPrice = 2000.0,
                            Description = "IT Stock",
                            Name = "TCS",
                            PortfolioID = 1,
                            PurchaseDate = new DateTime(2019, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isSold = false
                        },
                        new
                        {
                            EquityId = 2,
                            AcquiredPrice = 1000.0,
                            Description = "IT Stock",
                            Name = "INFY",
                            PortfolioID = 1,
                            PurchaseDate = new DateTime(2019, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isSold = false
                        },
                        new
                        {
                            EquityId = 3,
                            AcquiredPrice = 2000.0,
                            Description = "IT Stock",
                            Name = "INFY",
                            PortfolioID = 2,
                            PurchaseDate = new DateTime(2019, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isSold = false
                        },
                        new
                        {
                            EquityId = 4,
                            AcquiredPrice = 400.0,
                            Description = "Energy",
                            Name = "Adani",
                            PortfolioID = 3,
                            PurchaseDate = new DateTime(2019, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            isSold = false
                        });
                });

            modelBuilder.Entity("portfolioManagerDomain.Portfolio", b =>
                {
                    b.Property<int>("PortfolioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PortfolioId"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PortfolioId");

                    b.ToTable("Portfolios");

                    b.HasData(
                        new
                        {
                            PortfolioId = 1,
                            Description = "Purely riskfree saving",
                            Name = "Saving"
                        },
                        new
                        {
                            PortfolioId = 2,
                            Description = "Little risk and high return",
                            Name = "Investment"
                        },
                        new
                        {
                            PortfolioId = 3,
                            Description = "High Risk",
                            Name = "ShortTermInvestment"
                        });
                });

            modelBuilder.Entity("portfolioManagerDomain.Equity", b =>
                {
                    b.HasOne("portfolioManagerDomain.Portfolio", "Portfolio")
                        .WithMany("Equities")
                        .HasForeignKey("PortfolioID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Portfolio");
                });

            modelBuilder.Entity("portfolioManagerDomain.Portfolio", b =>
                {
                    b.Navigation("Equities");
                });
#pragma warning restore 612, 618
        }
    }
}
