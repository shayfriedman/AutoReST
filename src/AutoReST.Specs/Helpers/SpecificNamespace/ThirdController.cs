using System.Web.Mvc;

namespace AutoReST.Specs.Helpers.SpecificNamespace
{
    public class ThirdController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(Customer data)
        {
            return View();
        }


    }
}