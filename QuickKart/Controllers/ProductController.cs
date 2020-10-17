using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using QuickKartDataAccessLayer;
using QuickKartDataAccessLayer.Models;

namespace QuickKart.Controllers
{
    public class ProductController : Controller
    {
        private readonly QuickKartRepository _repObj;
        private readonly IMapper _mapper;
        public ProductController(QuickKartRepository repObj, IMapper mapper)
        {
            _repObj = repObj;
            _mapper = mapper;
        }

        public IActionResult ViewProducts()
        {
            var lstEntityProducts = _repObj.GetProducts();
            List<Models.Products> lstModelProducts = new List<Models.Products>();
            foreach (var product in lstEntityProducts)
            {
                lstModelProducts.Add(_mapper.Map<Models.Products>(product));
            }
            return View(lstModelProducts);
        }
        public IActionResult AddProduct()
        {
            string productId = _repObj.GetNextProductId();
            ViewBag.NextProductId = productId;
            return View();
        }
        public IActionResult SaveAddedProduct(Models.Products product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    status = _repObj.AddProduct(_mapper.Map<Products>(product));
                    if (status)
                        return RedirectToAction("ViewProducts");
                    else
                        return View("Error");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View("AddProduct", product);
        }
        public IActionResult UpdateProduct(Models.Products prodObj)
        {
            return View(prodObj);
        }
        public IActionResult SaveUpdatedProduct(Models.Products product)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    status = _repObj.UpdateProduct(_mapper.Map<Products>(product));
                    if (status)
                        return RedirectToAction("ViewProducts");
                    else
                        return View("Error");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View("UpdateProduct", product);
        }

        public IActionResult DeleteProduct(Models.Products product)
        {
            return View(product);
        }
        public IActionResult SaveDeletion(string productId)
        {
            bool status = false;
            try
            {
                status = _repObj.DeleteProduct(productId);
                if (status)
                    return RedirectToAction("ViewProducts");
                else
                    return View("Error");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
        public IActionResult GetProductForCategory(byte? categoryId)
        {
            ViewBag.CategoryList = _repObj.GetCategories();
            var productList = _repObj.GetProducts();
            var products = new List<Models.Products>();
            foreach (var product in productList)
            {
                products.Add(_mapper.Map<Models.Products>(product));
            }
            var filteredProducts = products.Where(model => model.CategoryId == categoryId);
            return View(filteredProducts);
        }









    }
}