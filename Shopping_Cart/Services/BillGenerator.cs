using Shopping_Cart.Models;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Cart.Services
{
    public class BillGenerator : IBill
    {
        SuperMarketContext ctx;
        public BillGenerator(SuperMarketContext c)
        {
            ctx = c;
        }
        public bool GenerateBill(BillMaster bill, BillDetail[] details)
        {
            int res = 0;
            bool isSuccess = false;

            ctx.BillMasters.Add(bill);
            ctx.BillDetails.AddRange(details);
            res = ctx.SaveChanges();
            if (res > 0)
            {
                isSuccess = true;
            }
            return isSuccess;
        }
    }
}