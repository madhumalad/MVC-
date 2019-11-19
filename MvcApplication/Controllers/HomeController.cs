using MvcApplication.Infrastructure;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        //Home/Details
        public JsonResult Details()
        {
            var obj = new { id = 1234, Name = "Canarys", Location = "begaluru" };
            return Json(obj, JsonRequestBehavior.AllowGet);
        }
        //Home/Today
        public string Today()
        {
            return DateTime.Now.ToString();
        }
        CategoryRepository categoryRepository = new CategoryRepository();
        NorthwindContext productDb = new NorthwindContext();
       // [HandleError(ExceptionType =typeof(Exception),View ="Error")]
        public ActionResult Index()
        {
            throw new Exception("Something went wrong");/*
            var model = new CategoryProductViewModel
            {
                Categories = categoryRepository.GetAll().ToList(),
                Products = productDb.Products.ToList(),
                SelectetCategoryId = 0,
                SelectedCategoryName = string.Empty

            };
            return View(model);
            */
        }
        [HttpPost]
        public ActionResult Index (FormCollection collection)
        {
            var id = Convert.ToInt32(collection["SelectedCategoryId"]);
            var products = productDb.Products.ToList();
            var categories = categoryRepository.GetAll();
            var selectedCategory = categories.FirstOrDefault(c => c.CategoryId == id);
            var matchingProducts = products.Where(c => c.CategoryId == selectedCategory.CategoryId);
            var model = new CategoryProductViewModel
            {
                Categories = categories.ToList(),
                Products = matchingProducts.ToList(),
                SelectedCategoryName = selectedCategory.CategoryName,
                SelectetCategoryId = selectedCategory.CategoryId
            };
            return View(model);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("home/customers/country/{country}")]
        public ActionResult GetCustomersByCountry(string country)
        {
            ViewBag.Message = "Customer by country name "+country;

            return View("Contact");
        }
        [Route("home/about-us/{option}")]
        public ActionResult AboutUs(int option)
        {
            ViewBag.One = "Something Else";
            ViewData["One"] = "Something";
            ViewData["ViewDataMessage"] = "This is form About Us Action->ViewDataMessage";
            ViewBag.ViewBagMessage = "This is from About-Us Action ->ViewBag Message";
            TempData["TempDataMessage"] = "This is from About-Us Action_>TempDataMessage";
            Session["SessionMessage"] = "This is from AboutUs Action ->SessionMessage";
            if (option == 0)
            {
                return View();

            }
            else
            {
                return RedirectToAction("AnotherAboutUs");
            }
        }
        [Route("home/another-about-us")]
        public ActionResult AnotherAboutUs()
        {
            return View();
        }
    }
}