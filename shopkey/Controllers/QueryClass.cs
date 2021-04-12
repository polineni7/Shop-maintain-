using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using shopkey.Models;

namespace shopkey.Controllers
{
    public class QueryClass
    {
        [ExtendObjectType(Name = "Query")]
        public class Queryclass
        {
            public IQueryable<Items> GetItems([Service] ShopkeyContext db)
            {
                return db.Items;
            }
            public IQueryable<Itemgroups> GetItemGroups([Service] ShopkeyContext db)
            {
                return db.Itemgroups;
            }
            public IQueryable<Purchasesheader> GetPurchaseheader([Service] ShopkeyContext db)
            {
                return db.Purchasesheader;
            }
            public IQueryable<Purchaseslines> GetPurchaselines([Service] ShopkeyContext db)
            {
                return db.Purchaseslines;
            }
            public IQueryable<Salesheader> GetSalesheader([Service] ShopkeyContext db)
            {
                return db.Salesheader;
            }
            public IQueryable<Salesline> GetSaleslines([Service] ShopkeyContext db)
            {
                return db.Salesline;
            }
            public IQueryable<Pricelist> GetPricelist([Service] ShopkeyContext db)
            {
                return db.Pricelist;
            }
            public IQueryable<Materialmanagement> GetMaterialmanagements([Service] ShopkeyContext db)
            {
                return db.Materialmanagement;
            }
        }
    }
}
