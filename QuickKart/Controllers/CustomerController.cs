using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;

namespace QuickKart.Controllers
{
    public class CustomerController : Controller
    {
        private readonly QuickKartRepository _repObj;
        public CustomerController(QuickKartRepository repObj)
        {
            _repObj = repObj;
        }

        public IActionResult CustomerHome()
        {
            List<string> lstProducts = new List<string>();
            lstProducts.Add("Dell Inspiron");
            lstProducts.Add("Marble chess board");
            lstProducts.Add("Adidas shoes");
            ViewBag.TopProducts = lstProducts;
            return View();
        }
    }
}