using MvcApplication.Infrastructure;
using MvcApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication.Controllers

{
   //can be used on the controller or action methods
    public class CustomerController : Controller
    {
        IRepository<Customer, string> repository;
        public CustomerController()
        {
            repository=new CustomerRepository();
        }
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model: model);
        }
        public ActionResult Details(string id)
        {
            var model = repository.GetDetails(identity: id);
                if (model != null)
                return View(model);
            else
                return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Edit(string id)
        {
            var model = repository.GetDetails(identity: id);
            if (model != null)
                return View(model: model);
            else
                return RedirectToAction("Index");
        }
        [HttpPost]

        //public ActionResult Edit()
        //{
        //    string id = Request.Form["CustomerID"];
        //    string companyName = Request.Form["CompanyName"];
        //    string contactName = Request.Form["ContactName"];
        //    string city = Request.Form["City"];
        //    string country = Request.Form["Country"];
        //    Customer model = new Customer
        //    {
        //      CustomerID = id,
        //      CompanyName=companyName,
        //      ContactName=contactName,
        //      City=city,
        //      Country=country

        //    };
        //    //repository.Update(model);
        //    return RedirectToAction("Index");
        //}
        //public ActionResult Edit(FormCollection theForm)
        //{
        //    string id = theForm["CustomerID"];
        //    string companyName = theForm["CompanyName"];
        //    string contactName = theForm["ContactName"];
        //    string city = theForm["City"];
        //    string country = theForm["Country"];
        //    Customer model = new Customer
        //    {
        //        CustomerID = id,
        //        CompanyName = companyName,
        //        ContactName = contactName,
        //        City = city,
        //        Country = country

        //    };
        //    //repository.Update(model);
        //    return RedirectToAction("Index");
        //}
        public ActionResult Edit(Customer model)
        {
            repository.Update(model);
            return RedirectToAction("Index");
        }
        
        public ActionResult Create()
        {
            var model = new Customer();
            return View(model: model);
        }

        [HttpPost]
        public ActionResult Create(Customer model)
        {
            repository.CreateNew(model);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(string id)
        {
            var model = repository.GetDetails(identity: id);
            return View(model: model);
        }
        [HttpPost]
        public ActionResult DeleteConfirm(string id)
        {
            repository.Delete(id);
            return RedirectToAction("Index");
        }
    }
}