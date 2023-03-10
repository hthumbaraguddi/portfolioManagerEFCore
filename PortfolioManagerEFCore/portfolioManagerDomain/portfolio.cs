using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolioManagerDomain
{
    public class Portfolio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PortfolioId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public List<Equity> Equities { get; set; }


    }
}
