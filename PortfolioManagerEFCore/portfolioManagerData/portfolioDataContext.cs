﻿using Microsoft.EntityFrameworkCore;
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
            modelBuilder.Entity<Portfolio>().HasMany<Equity>().WithOne();
        }

    }
}
