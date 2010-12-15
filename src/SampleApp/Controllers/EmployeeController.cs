using System;
using System.Web.Mvc;
using AutoReST.Specs.Helpers;

namespace SampleApp.Controllers
{
    public class EmployeeController : Controller
    {
        public ActionResult List()
        {
            return View();
        }


        public ActionResult Details(int id)
        {
            return View();
        }



        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Employee data)
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

        public ActionResult Edit(int id, Employee data)
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