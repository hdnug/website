using System.Web.Mvc;
using Hdnug.Domain.Constants;

namespace Hdnug.Web.Areas.Admin.Controllers
{
    public class HomeController : AdminAreaBaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}