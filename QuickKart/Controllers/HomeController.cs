using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickKart.Models;
using QuickKartDataAccessLayer;

namespace QuickKart.Controllers
{
    public class HomeController : Controller
    {
        private readonly QuickKartRepository _repObj;
        public HomeController(QuickKartRepository repObj)
        {
            _repObj = repObj;
        }
       

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public JsonResult GetCoupons()
        {
            Random random = new Random();
            Dictionary<string, string> data = new Dictionary<string, string>();
            string[] value = new String[5];
            string[] key = { "Arts", "Electronics", "Fashion", "Home", "Toys" };
            for (int i = 0; i < 5; i++)
            {
                string number = "RUSH" + random.Next(1, 10).ToString() + random.Next(1, 10).ToString() + random.Next(1, 10).ToString();
                value[i] = number;
            }
            for (int i = 0; i < 5; i++)
            {
                data.Add(key[i], value[i]);
            }
            return Json(data);
        }

        public RedirectResult FAQ()
        {
            return Redirect("/Home/Contact");
        }


        public IActionResult CheckRole(IFormCollection frm)
        {
            string userId = frm["name"];
            string password = frm["pwd"];
            string checkbox = frm["RememberMe"];

            if (checkbox == "on")
            {
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("UserId", userId, option);
                Response.Cookies.Append("Password", password, option);
            }

            string username = userId.Split('@')[0];

            byte? roleId = _repObj.ValidateCredentials(userId, password);
            if (roleId == 1)
            {
                HttpContext.Session.SetString("username", username);
                return RedirectToAction("AdminHome", "Admin");
            }
            else if (roleId == 2)
            {
                HttpContext.Session.SetString("Customer_userId", userId);
                return Redirect("/Customer/CustomerHome?username=" + username);
            }
            return View("Login");
        }






        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
