using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QuickKart.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult AdminHome()
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