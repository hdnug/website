using System.Linq;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Models.ViewModels;
using Highway.Data;

namespace Hdnug.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository _repo;

        public HomeController(IRepository repo)
        {
            _repo = repo;
        }

        public ActionResult Index()
        {
            var meetings = _repo.Find(new FindAll<Meeting>()).ToList();
            var sliderImages = _repo.Find(new AllSliderImages()).ToList();
            var viewModel = new HomeViewModel
            {
                Meetings = meetings,
                SliderImages = sliderImages
            };
             
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}