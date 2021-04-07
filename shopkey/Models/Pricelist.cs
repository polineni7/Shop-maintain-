using System;
using System.Collections.Generic;

namespace shopkey.Models
{
    public partial class Pricelist
    {
        public Pricelist()
        {
            Purchaseslines = new HashSet<Purchaseslines>();
            Salesline = new HashSet<Salesline>();
        }

        public int Itemid { get; set; }
        public double? Rat { get; set; }

        public virtual Items Item { get; set; }
        public virtual ICollection<Purchaseslines> Purchaseslines { get; set; }
        public virtual ICollection<Salesline> Salesline { get; set; }
    }
}
