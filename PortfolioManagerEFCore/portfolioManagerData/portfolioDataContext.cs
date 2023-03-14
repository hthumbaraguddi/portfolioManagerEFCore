using Microsoft.EntityFrameworkCore;
using portfolioManagerDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolioManagerData
{
    public class PortfolioDataContext : DbContext
    {
        public DbSet<Portfolio> Portfolios { get; set; } = null;

        public DbSet<Equity> Equity { get; set; } = null;


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PortfolioDB; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Call this when domainObjects don't have any relationships defined 
            // with mentioned property reference. 
            //modelBuilder.Entity<Portfolio>()
            //    .HasMany<Equity>(folio => folio.Equities)
            //    .WithOne(eqi => eqi.Portfolio)
            //    .HasForeignKey(eqi => eqi.PortfolioID);


            //Following the to define the relationship, One to Many with ForeignKey as null. 
            //Its is like you got some positions but you don't have portfolio to assign. 
            //ofcourse, the following you will also mention that propery (PortfolioID) as nullable. 
            //modelBuilder.Entity<Portfolio>()
            //    .HasMany<Equity>(folio => folio.Equities)
            //    .WithOne(eqi => eqi.Portfolio)
            //    .HasForeignKey(eqi => eqi.PortfolioID)
            //    .IsRequired(false);



            //Seeding Some Data

            //single portfolio
            modelBuilder.Entity<Portfolio>().HasData(
                new Portfolio { Name = "Saving", Description = "Purely riskfree saving", PortfolioId = 1 });

            //Multiple portfolio

            var folioList = new List<Portfolio>()
            {
                new Portfolio { Name = "Investment", Description = "Little risk and high return", PortfolioId = 2 },
                new Portfolio { Name = "ShortTermInvestment", Description = "High Risk", PortfolioId = 3 }
            };

            modelBuilder.Entity<Portfolio>().HasData(folioList);

            //Add some Stocks to these portfolios

            var stocks = new Equity[]
            {
                new Equity {EquityId=1, Name="TCS", AcquiredPrice=2000, Description="IT Stock", isSold=false, PurchaseDate=new DateTime(2019, 6, 7), PortfolioID=1},
                new Equity {EquityId=2,Name="INFY", AcquiredPrice=1000, Description="IT Stock", isSold=false, PurchaseDate=new DateTime(2019, 6, 7), PortfolioID=1},
                new Equity {EquityId=3,Name="INFY", AcquiredPrice=2000, Description="IT Stock", isSold=false, PurchaseDate=new DateTime(2019, 6, 7), PortfolioID=2},
                new Equity {EquityId=4 ,Name="Adani", AcquiredPrice=400, Description="Energy", isSold=false, PurchaseDate=new DateTime(2019, 6, 7), PortfolioID=3}

            };

            modelBuilder.Entity<Equity>().HasData(stocks);
        }

    }
}
