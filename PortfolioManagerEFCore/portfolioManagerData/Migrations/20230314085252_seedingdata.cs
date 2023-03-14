using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace portfolioManagerData.Migrations
{
    public partial class seedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "PortfolioId", "Description", "Name" },
                values: new object[] { 1, "Purely riskfree saving", "Saving" });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "PortfolioId", "Description", "Name" },
                values: new object[] { 2, "Little risk and high return", "Investment" });

            migrationBuilder.InsertData(
                table: "Portfolios",
                columns: new[] { "PortfolioId", "Description", "Name" },
                values: new object[] { 3, "High Risk", "ShortTermInvestment" });

            migrationBuilder.InsertData(
                table: "Equity",
                columns: new[] { "EquityId", "AcquiredPrice", "Description", "Name", "OverallPnL", "PortfolioID", "PurchaseDate", "SoldPrice", "isSold" },
                values: new object[,]
                {
                    { 1, 2000.0, "IT Stock", "TCS", null, 1, new DateTime(2019, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false },
                    { 2, 1000.0, "IT Stock", "INFY", null, 1, new DateTime(2019, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false },
                    { 3, 2000.0, "IT Stock", "INFY", null, 2, new DateTime(2019, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false },
                    { 4, 400.0, "Energy", "Adani", null, 3, new DateTime(2019, 6, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Equity",
                keyColumn: "EquityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Equity",
                keyColumn: "EquityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Equity",
                keyColumn: "EquityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Equity",
                keyColumn: "EquityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Portfolios",
                keyColumn: "PortfolioId",
                keyValue: 3);
        }
    }
}
