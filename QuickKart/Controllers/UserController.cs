using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;

namespace QuickKart.Controllers
{
    public class UserController : Controller
    {
        private readonly QuickKartRepository _repObj;
        public UserController(QuickKartRepository repObj)
        {
            _repObj = repObj;
        }
        public IActionResult SaveRegisterUser(Models.Users userObj)
        {
            if (ModelState.IsValid)
            {
                var returnValue = _repObj.RegisterUser(userObj.EmailId, userObj.UserPassword, userObj.Gender, userObj.DateOfBirth, userObj.Address);
                if (returnValue)
                    return RedirectToAction("Login", "Home");
                else
                    return View("Error");
            }
            return View("RegisterUser");
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
    }
}