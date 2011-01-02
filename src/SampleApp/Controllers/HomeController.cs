using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleApp.Controllers
{
	public class Person
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime BirthDate { get; set; }
		public string Country { get; set; }
		public string City { get; set; }
		public List<int> LuckyNumbers { get; set; }
	}

    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
        	var person = new Person()
        	             	{
        	             		FirstName = "Shay",
        	             		LastName = "Friedman",
        	             		BirthDate = new DateTime(1983, 9, 6),
        	             		Country = "Israel",
        	             		City = "Herzeliyya",
        	             		LuckyNumbers = new List<int>() {1, 2, 3, 4, 5, 6, 7}
        	             	};
            return View(person);
        }

    }
}
