using Shopping_Cart.Models;
using Shopping_Cart.Services;
using Shopping_Cart.SessionExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Shopping_Cart.Controllers
{
    public class FinalBillController : Controller
    {
        IBill finalBill;

        public FinalBillController(IBill fb)
        {
            finalBill = fb;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var selProducts = HttpContext.Session.GetSessionData<List<BillDetail>>("PurchasedProduct");

            var billMaster = new BillMaster();
            //Calculate the Total Bill Amount
            foreach (var item in selProducts)
            {
                billMaster.BillAmount += item.RowPrice;
            }

            billMaster.BillDetails = selProducts;

            finalBill.GenerateBill(billMaster, billMaster.BillDetails.ToArray());

            return View(billMaster);
        }


    }
}