using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolioManagerDomain
{
    public class Equity
    {
        public int Id;
        public string Name;
        public string Description;
        public Equity() { }
        public DateTime PurchaseDate { get; set; }
        public double AcquiredPrice { get; set; }
        public double? SoldPrice { get; set;}
        public bool isSold { get; set; }
        public double? OverallPnL { get;set; }

    }
}
