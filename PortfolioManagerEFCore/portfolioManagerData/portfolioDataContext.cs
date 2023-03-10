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
        public DbSet<Portfolio> Portfolios { get; set; }

        public DbSet<Equity> Equity { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PortfolioDB; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
                );
        }

    }
}
