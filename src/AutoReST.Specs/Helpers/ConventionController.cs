using System.Web.Mvc;

namespace AutoReST.Specs.Helpers
{
    public class ConventionController: Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Customer data)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            return View();
        }

        public ActionResult Update(Customer data)
        {
            return View();
        }
    }
}