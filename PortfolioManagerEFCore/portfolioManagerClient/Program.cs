

using Microsoft.EntityFrameworkCore;
using portfolioManagerData;
using portfolioManagerDomain;

//Little cheat, this will create a new DataBase
//using (PortfolioDataContext context = new PortfolioDataContext())
//{
//    context.Database.EnsureCreated();
//}


//populate some data

//PopulateData();
//GetData();

//Pagging
//AddSomePortflios();
// GetPagedInformation();

//Sorting orderBy and thenby
//SortingPortfolios();



/*Loading or retriving the data*/
//EagerLoadingPortfolioAndEquities();
ExplicitLoadCollection();
static void EagerLoadingPortfolioAndEquities()
{
    PortfolioDataContext context = new PortfolioDataContext();
    var portfolios = context.Portfolios.Include(a => a.Equities).AsSplitQuery().ToList();

    portfolios.ForEach(folio =>
    {
    Console.WriteLine($"folioName:{folio.Name}");
    folio.Equities.ForEach(e => Console.WriteLine( e.Name) );
            
    });
}



static void ExplicitLoadCollection()
{
    PortfolioDataContext context = new PortfolioDataContext();
    var folio =   context.Portfolios.FirstOrDefault(a => a.Name == "Saving");
    //context.Entry(folio).Collection(a=>a.Equities).Load();

    //for any explicit filtering then 
    context.Entry(folio).Collection(a => a.Equities).Query().Where(b => b.Name == "INFY")
        .ToList().ForEach(e => Console.WriteLine(e.Name));


}
static void EagerLoadingPortfolioAndEquitiesWithPaging()
{

}
static void GetData()
{
    PortfolioDataContext context = new PortfolioDataContext();
    var folio = context.Portfolios.ToList();
    var equities = context.Equity.ToList();

}

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


    //Some more information

}

static void AddSomePortflios()
{
    PortfolioDataContext context = new PortfolioDataContext();
    Portfolio folio2 = new Portfolio() { Name = "BikePurchase", Description = "Onthe Fly", Equities = new List<Equity>() };
    Portfolio folio3 = new Portfolio() { Name = "Son Higher Education", Description = "Monthly SIP", Equities = new List<Equity>() };
    Portfolio folio4 = new Portfolio() { Name = "Second innings", Description = "Monthly SIP", Equities = new List<Equity>() };
    context.Portfolios.Add(folio2);
    context.Portfolios.Add(folio3);
    context.Portfolios.Add(folio4);
    context.SaveChanges();
}

//Page based retrival

static void GetPagedInformation()
{
    var context = new PortfolioDataContext();
    var groupSize = 2;
    int maxfoliosToCycle= (int)Math.Ceiling((decimal)(context.Portfolios.Count()/groupSize));
    
    for(int i =0;i< maxfoliosToCycle; i++)
    {
        var folio = context.Portfolios.Skip(groupSize * i).Take(groupSize).ToList();
        foreach(var f in folio)
        {
            Console.WriteLine($"{f.Name}  {f.Description}");
        }

    }
}

static void SortingPortfolios()
{
    var context = new PortfolioDataContext();
    
    var portfolios = context.Portfolios.OrderBy(f => f.Name).ThenBy(a=>a.Description).ToList();

    portfolios.ForEach(a => Console.WriteLine($"{a.Name} {a.Description}"));
}




