using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hdnug.Web.Controllers
{
    public class UpcomingMeetingsController : Controller
    {
        // GET: UpcomingMeetings
        public ActionResult Index()
        {
            return View();
        }
    }
}