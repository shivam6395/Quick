using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;
using AutoMapper;

namespace QuickKart.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly QuickKartRepository _repObj;
        private readonly IMapper _mapper;
        public PurchaseController(QuickKartRepository repObj, IMapper mapper)
        {
            _repObj = repObj;
            _mapper = mapper;
        }

        public IActionResult PurchaseProduct(Models.Products productObj)
        {
            Models.PurchaseDetails purchaseObj = new Models.PurchaseDetails();
            purchaseObj.EmailId = HttpContext.Session.GetString("Customer_userId").ToString();
            purchaseObj.ProductId = productObj.ProductId;
            purchaseObj.DateOfPurchase = DateTime.Now;
            TempData["ProductName"] = productObj.ProductName;
            return View(purchaseObj);
        }


        public ActionResult SavePurchase(Models.PurchaseDetails purchaseObj)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    ViewData["QuantityPurchased"] = purchaseObj.QuantityPurchased;
                    var status = _repObj.PurchaseProduct(_mapper.Map<PurchaseDetails>(purchaseObj));
                    if (status)
                        return View("Success");
                    else
                        return View("Error");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View("PurchaseProduct", purchaseObj);
        }



    }
}