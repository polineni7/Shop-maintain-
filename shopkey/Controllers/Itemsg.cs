using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using shopkey.Models;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;
using HotChocolate.Subscriptions;

namespace shopkey.Controllers
{
    [ExtendObjectType(Name ="Query")]
    public class Itemsg
    {
        public IQueryable<Models.Itemgroups> GetItemgroups([Service] ShopkeyContext db)
        {
            return db.Itemgroups;
        }

        public IQueryable<Items> GetItems([Service] ShopkeyContext db)
        {
            return db.Items;
        }

        public IQueryable<Materialmanagement> GetMaterialmanagements ([Service] ShopkeyContext db)
        {

            return db.Materialmanagement;
        }

    }
}
