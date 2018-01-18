using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VideoRentalApplication.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult GetLocation()
        {
            //ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult IssueTracker()
        {
                       
            /*ViewBag.Severity = new List<SelectListItem>{
            new SelectListItem { Text = "Low", Value = "Low" },
            new SelectListItem { Text = "Medium", Value = "Medium" },
            new SelectListItem { Text = "High", Value = "High" }
            }; */

            return View();            
        }
    }
}
