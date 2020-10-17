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
    public class CategoriesController : Controller
    {
        private readonly QuickKartRepository _repObj;
        private readonly IMapper _mapper;
        public CategoriesController(QuickKartRepository repObj, IMapper mapper)
        {
            _repObj = repObj;
            _mapper = mapper;
        }

        public IActionResult ViewCategories()
        {
            var lstEntityCategories = _repObj.GetCategories();
            List<Models.Categories> lstModelCategories = new List<Models.Categories>();
            foreach (var categories in lstEntityCategories)
            {
                lstModelCategories.Add(_mapper.Map<Models.Categories>(categories));
            }
            return View(lstModelCategories);
        }
        public IActionResult AddCategories()
        {
            return View();
        }
        public IActionResult SaveAddedCategories(Models.Categories categories)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    status = _repObj.AddCategory(_mapper.Map<Categories>(categories));
                    if (status)
                        return RedirectToAction("ViewCategories");
                    else
                        return View("Error");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View("AddCategories", categories);
        }
        public IActionResult UpdateCategories(string categoriesName)
        {
            return View(categoriesName);
        }
        public IActionResult SaveUpdatedCategories(string categoriesName)
        {
            bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    status = _repObj.UpdateCategory(_mapper.Map<Categories>(categoriesName));
                    if (status)
                        return RedirectToAction("ViewCategories");
                    else
                        return View("Error");
                }
                catch (Exception)
                {
                    return View("Error");
                }
            }
            return View("UpdateCategories", categoriesName);
        }

        public IActionResult DeleteCategories(Models.Categories categories)
        {
            return View(categories);
        }
        public IActionResult SaveDeletion(Categories catObj)
        {
            bool status = false;
            try
            {
                status = _repObj.DeleteCategory(catObj);
                if (status)
                    return RedirectToAction("ViewCategories");
                else
                    return View("Error");
            }
            catch (Exception)
            {
                return View("Error");
            }
        }
    }
}