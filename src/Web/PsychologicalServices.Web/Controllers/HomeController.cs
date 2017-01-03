using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PsychologicalServices.Web.Controllers
{
    //[RequireHttps]
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return File("~/wwwroot/index.html", "text/html");
            return View();
        }
    }
}
