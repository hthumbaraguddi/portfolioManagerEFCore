using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolioManagerDomain
{
    public class portfolio
    {
        public int id;

        public string Name;

        public string Description;
        public List<Equity> Equities { get; set; }

    }
}
