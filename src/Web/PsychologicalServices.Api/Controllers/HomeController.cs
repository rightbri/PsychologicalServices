using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PsychologicalServices.Api.Controllers
{
    //[RequireHttps]
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
