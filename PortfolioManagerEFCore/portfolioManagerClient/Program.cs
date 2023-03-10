

using portfolioManagerData;
using portfolioManagerDomain;

//Little cheat, this will create a new DataBase
using (PortfolioDataContext context = new PortfolioDataContext())
{
    //context.Database.EnsureCreated();
}


//populate some data

PopulateData();

static void PopulateData()
{
    //first acquire the database context

    PortfolioDataContext context = new PortfolioDataContext();

    //first create one portfolio

    Portfolio folio = new Portfolio() { Name = "Investment", Description = "Monthly SIP", Equities= new List<Equity>() };
    folio.Equities.Add(new Equity() { Name = "Infy", AcquiredPrice = 650, Description = "Tech Stack", isSold = false, PurchaseDate = new DateTime(2019, 6, 7), OverallPnL = 0 });
    folio.Equities.Add(new Equity() { Name = "TCS", AcquiredPrice = 1850, Description = "Tech Stack", isSold = false, PurchaseDate = new DateTime(2019, 10, 4), OverallPnL = 0 });
    context.Portfolios.Add(folio);
    context.SaveChanges();   

}




