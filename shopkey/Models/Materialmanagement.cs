using System;
using System.Collections.Generic;

namespace shopkey.Models
{
    public partial class Materialmanagement
    {
        public int Transno { get; set; }
        public int? Traid { get; set; }
        public int? Tartype { get; set; }
        public int? Qtyin { get; set; }
        public int? Qtyout { get; set; }
        public double? Rat { get; set; }
    }
}
