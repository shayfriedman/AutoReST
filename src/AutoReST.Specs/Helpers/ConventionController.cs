using System.Web.Mvc;

namespace AutoReST.Specs.Helpers
{
    public class ConventionController: Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Customer customer)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Update()
        {
            return View();
        }

        public ActionResult Update(Customer customer)
        {
            return View();
        }
    }
}