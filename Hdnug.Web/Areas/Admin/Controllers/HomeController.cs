using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hdnug.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}