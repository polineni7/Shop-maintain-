using System;
using System.Collections.Generic;

namespace shopkey.Models
{
    public partial class Salesline
    {
        public int? Billno { get; set; }
        public int? Sno { get; set; }
        public int? Itemname { get; set; }
        public int? Qty { get; set; }
        public double? Rat { get; set; }

        public virtual Salesheader BillnoNavigation { get; set; }
        public virtual Pricelist ItemnameNavigation { get; set; }
    }
}
