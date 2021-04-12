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
    public class MutationClass
    {
        public class itemgrouwrapper
        {
            public Itemgroups itemgroups { get; set; }
            public int txnCheck { get; set; }
            public String result { get; set; }

        }
        public class itemsswrapper
        {
            public Items items { get; set; }
            public int txnCheck1 { get; set; }
            public String result1 { get; set; }

        }


        public class pricelistswrapper
        {
            public Pricelist pricelist { get; set; }
            public int txnCheck2 { get; set; }
            public String result2 { get; set; }

        }
        public class purchasesheaderswrapper
        {
            public Purchasesheader purchasesheader { get; set; }
            public int txnCheck3 { get; set; }
            public String result3 { get; set; }

        }
        public class purchaselinesswrapper
        {
            public Purchaseslines purchaseslines  { get; set; }
            public int txnCheck4 { get; set; }
            public String result4 { get; set; }

        }
        public class saleshaderswrapper
        {
            public Salesheader salesheader { get; set; }
            public int txnCheck5 { get; set; }
            public String result5 { get; set; }

        }
        public class saleslineswrapper
        {
            public Salesline salesline { get; set; }
            public int txnCheck6 { get; set; }
            public String result6 { get; set; }

        }
        public class Materialmanagementswrapper
        {
            public Materialmanagement materialmanagement { get; set; }
            public int txnCheck7 { get; set; }
            public String result7 { get; set; }
        }


        [ExtendObjectType(Name = "Mutation")]
        public class mutationClass

        {
            public String setitems([Service] ShopkeyContext db, itemgrouwrapper it)
            {
                String msg = "";
                try
                {
                    switch (it.txnCheck)
                    {
                        case 1:
                            db.Itemgroups.Add(it.itemgroups);
                            db.SaveChanges();
                            msg = "ok";
                            break;
                        case 2:
                            var adit = db.Itemgroups.Where(a => a.Grpid == it.itemgroups.Grpid).FirstOrDefault();
                            adit.Grpname = it.itemgroups.Grpname;
                            adit.Maingrp = it.itemgroups.Maingrp;
                            msg = "ok";
                            db.SaveChanges();
                            break;
                        case 3:
                            var itm = db.Itemgroups.Where(a => a.Grpid == it.itemgroups.Grpid).FirstOrDefault();
                            db.Remove(itm);
                            db.SaveChanges();
                            msg = "ok";
                            break;

                    }
                }
                catch (Exception ee)
                {
                    return ee.Message;
                }

                it.result = msg;
                return it.result;
              
            }

            private int? findId()
            {
                int? x = 0;
                ShopkeyContext db = new ShopkeyContext();
                var xx = db.Itemgroups.FirstOrDefault();
                if (xx != null)
                {
                    x = db.Itemgroups.Max(a => a.Grpid);
                }

                x = x + 1;
                return x;
            }

        }
            public String setiteamss([Service] ShopkeyContext db, itemsswrapper ite)
        {
            String msg = "";
            try
            {
                switch (ite.txnCheck1)
                {
                    case 1:
                        db.Items.Add(ite.items);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 2:
                        var modi = db.Items.Where(a => a.Itemid == ite.items.Itemid).FirstOrDefault();
                        modi.Itemname = ite.items.Itemname;
                        modi.Grpid = ite.items.Grpid;
                        modi.Uom = ite.items.Uom;
                        msg = "ok";
                        db.SaveChanges();
                        break;
                    case 3:
                        var irm = db.Itemgroups.Where(a => a.Grpid == ite.items.Itemid).FirstOrDefault();
                        db.Remove(irm);
                        db.SaveChanges();
                        msg = "ok";
                        break;

                }
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            ite.result1 = msg;
            return ite.result1;

        }

        private int? findId()
        {
            int? x = 0;
            ShopkeyContext db = new ShopkeyContext();
            var xx = db.Items.FirstOrDefault();
            if (xx != null)
            {
                x = db.Items.Max(a => a.Itemid);
            }

            x = x + 1;
            return x;
        }

        public String setprices([Service] ShopkeyContext db, pricelistswrapper itee)
        {
            String msg = "";
            try
            {
                switch (itee.txnCheck2)
                {
                    case 1:
                        db.Pricelist.Add(itee.pricelist);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 2:
                        var modi = db.Pricelist.Where(a => a.Itemid == itee.pricelist.Itemid).FirstOrDefault();
                        modi.Rat = itee.pricelist.Rat;
                        msg = "ok";
                        db.SaveChanges();
                        break;
                    case 3:
                        var irm = db.Pricelist.Where(a => a.Itemid == itee.pricelist.Itemid).FirstOrDefault();
                        db.Remove(irm);
                        db.SaveChanges();
                        msg = "ok";
                        break;

                }
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            itee.result2 = msg;
            return itee.result2;

        }

        public String setPurchasesheaders([Service] ShopkeyContext db, purchasesheaderswrapper iteee)
        {
            String msg = "";
            try
            {
                switch (iteee.txnCheck3)
                {
                    case 1:
                        db.Purchasesheader.Add(iteee.purchasesheader);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 2:
                        var modi = db.Purchasesheader.Where(a => a.Mir == iteee.purchasesheader.Mir).FirstOrDefault();
                        modi.Purchesesdate = iteee.purchasesheader.Purchesesdate;
                        modi.Suppliers = iteee.purchasesheader.Suppliers;
                        modi.Mobile = iteee.purchasesheader.Mobile;
                        modi.Taxes = iteee.purchasesheader.Taxes;
                        modi.Totamt = iteee.purchasesheader.Totamt;
                        modi.Discount = iteee.purchasesheader.Discount;
                        modi.Totamt = iteee.purchasesheader.Totamt;
                        msg = "ok";
                        db.SaveChanges();
                        break;
                    case 3:
                        var irm = db.Purchasesheader.Where(a => a.Mir == iteee.purchasesheader.Mir).FirstOrDefault();
                        db.Remove(irm);
                        db.SaveChanges();
                        msg = "ok";
                        break;

                }
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            iteee.result3 = msg;
            return iteee.result3;

        }
        public String setPurchselines([Service] ShopkeyContext db, purchaselinesswrapper iteeee)
        {
            String msg = "";
            try
            {
                switch (iteeee.txnCheck4)
                {
                    case 1:
                        db.Purchaseslines.Add(iteeee.purchaseslines);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 2:
                        var modi = db.Purchaseslines.Where(a => a.Mir == iteeee.purchaseslines.Sno).FirstOrDefault();
                        modi.Pitem = iteeee.purchaseslines.Pitem;
                        modi.Rat = iteeee.purchaseslines.Rat;
                        
                        msg = "ok";
                        db.SaveChanges();
                        break;
                    case 3:
                        var irm = db.Purchasesheader.Where(a => a.Mir == iteeee.purchaseslines.Sno).FirstOrDefault();
                        db.Remove(irm);
                        db.SaveChanges();
                        msg = "ok";
                        break;

                }
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            iteeee.result4 = msg;
            return iteeee.result4;

        }
        public String setsaleshaders([Service] ShopkeyContext db, saleshaderswrapper iteeeee)
        {
            String msg = "";
            try
            {
                switch (iteeeee.txnCheck5)
                {
                    case 1:
                        db.Salesheader.Add(iteeeee.salesheader);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 2:
                        var modi = db.Salesheader.Where(a => a.Billno == iteeeee.salesheader.Billno).FirstOrDefault();
                        modi.Salesdate = iteeeee.salesheader.Salesdate;
                        modi.Cname = iteeeee.salesheader.Cname;
                        modi.Mobile = iteeeee.salesheader.Mobile;
                        modi.Baseamt = iteeeee.salesheader.Baseamt;
                        modi.Taxes = iteeeee.salesheader.Taxes;
                        modi.Discount = iteeeee.salesheader.Discount;
                        modi.Totamt = iteeeee.salesheader.Totamt;
                        msg = "ok";
                        db.SaveChanges();
                        break;
                    case 3:
                        var irm = db.Salesheader.Where(a => a.Billno == iteeeee.salesheader.Billno).FirstOrDefault();
                        db.Remove(irm);
                        db.SaveChanges();
                        msg = "ok";
                        break;

                }
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            iteeeee.result5 = msg;
            return iteeeee.result5;

        }
        public String setsaleslines([Service] ShopkeyContext db, saleslineswrapper iteeeeee)
        {
            String msg = "";
            try
            {
                switch (iteeeeee.txnCheck6)
                {
                    case 1:
                        db.Salesline.Add(iteeeeee.salesline);
                        db.SaveChanges();
                        msg = "ok";
                        break;
                    case 2:
                        var modi = db.Salesline.Where(a => a.Billno == iteeeeee.salesline.Sno).FirstOrDefault();
                        modi.Itemname = iteeeeee.salesline.Itemname;
                        modi.Rat = iteeeeee.salesline.Rat;

                        msg = "ok";
                        db.SaveChanges();
                        break;
                    case 3:
                        var irm = db.Salesline.Where(a => a.Billno == iteeeeee.salesline.Sno).FirstOrDefault();
                        db.Remove(irm);
                        db.SaveChanges();
                        msg = "ok";
                        break;

                }
            }
            catch (Exception ee)
            {
                return ee.Message;
            }

            iteeeeee.result6 = msg;
            return iteeeeee.result6;

        }
    }
}

