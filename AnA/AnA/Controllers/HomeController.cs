using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnA.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        public ActionResult MainPage()
        {
            return View();
        }

        //
        // Get: Panel Members for get details 
        public ActionResult PanelMembers()
        {
            return View();
        }
	}
}