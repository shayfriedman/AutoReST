using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoReST.Specs.Helpers;

namespace SampleApp.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }

       
        [HttpGet]
        public ActionResult Details(int id)
        {
            return View();
        }

        
       
        public ActionResult Create()
        {
            return View();
        } 

        public ActionResult Create(Customer customer)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        
        public ActionResult Edit(int id)
        {
            return View();
        }

        public ActionResult Edit(int id, Customer customer)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

 
    }
}
