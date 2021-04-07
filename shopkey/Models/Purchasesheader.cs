using System;
using System.Collections.Generic;

namespace shopkey.Models
{
    public partial class Purchasesheader
    {
        public Purchasesheader()
        {
            Purchaseslines = new HashSet<Purchaseslines>();
        }

        public int Mir { get; set; }
        public DateTime? Purchesesdate { get; set; }
        public string Suppliers { get; set; }
        public string Mobile { get; set; }
        public double? Baseamt { get; set; }
        public double? Taxes { get; set; }
        public double? Discount { get; set; }
        public double? Totamt { get; set; }

        public virtual ICollection<Purchaseslines> Purchaseslines { get; set; }
    }
}
