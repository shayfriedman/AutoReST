using System.Web.Mvc;

namespace AutoReST.Specs.Helpers
{
    public class ActionController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Customer data)
        {
            return View();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Update(int id)
        {
            return View();
        }

        [HttpPut]
        public ActionResult Update(Customer data)
        {
            return View();
        }
    }
}