using System;
using System.Collections.Generic;

namespace shopkey.Models
{
    public partial class Items
    {
        public int Itemid { get; set; }
        public string Itemname { get; set; }
        public int? Grpid { get; set; }
        public string Uom { get; set; }

        public virtual Itemgroups Grp { get; set; }
        public virtual Pricelist Pricelist { get; set; }
    }
}
