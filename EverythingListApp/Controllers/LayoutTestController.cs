using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EverythingListApp.Controllers
{
    public class LayoutTestController : Controller
    {
        // GET: LayoutTest
        public ActionResult Index()
        {
            return View();
        }

        // GET: LayoutTest
        public ActionResult Tours()
        {
            return View();
        }

        // GET: LayoutTest
        public ActionResult About()
        {
            return View();
        }

        // GET: LayoutTest
        public ActionResult Contact()
        {
            return View();
        }
    }
}