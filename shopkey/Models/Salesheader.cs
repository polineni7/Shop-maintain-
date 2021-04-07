using System;
using System.Collections.Generic;

namespace shopkey.Models
{
    public partial class Salesheader
    {
        public Salesheader()
        {
            Salesline = new HashSet<Salesline>();
        }

        public int Billno { get; set; }
        public DateTime? Salesdate { get; set; }
        public string Cname { get; set; }
        public string Mobile { get; set; }
        public double? Baseamt { get; set; }
        public double? Taxes { get; set; }
        public double? Discount { get; set; }
        public double? Totamt { get; set; }

        public virtual ICollection<Salesline> Salesline { get; set; }
    }
}
