﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace portfolioManagerDomain
{
    public class Equity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        public Equity() { }
        public DateTime PurchaseDate { get; set; }
        public double AcquiredPrice { get; set; }
        public double? SoldPrice { get; set;}
        public bool isSold { get; set; }
        public double? OverallPnL { get;set; }

    }
}
