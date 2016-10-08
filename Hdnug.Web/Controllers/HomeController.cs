using System.Linq;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Models.ViewModels;
using Highway.Data;
using Hdnug.Web.Inrastructure.Interfaces;

namespace Hdnug.Web.Controllers
{
    public class HomeController : Controller
    {

        private readonly IRepository _repo;
        private readonly IMailingListService _mailingListService;

        public HomeController(IRepository repo, IMailingListService mailingListService)
        {
            _repo = repo;
            _mailingListService = mailingListService;
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

        [HttpPost]
        public ActionResult Mailinglist(string firstname, string lastname, string company, string email)
        {
            _repo.Execute(new AddMember(firstname, lastname, company, email));
            _mailingListService.AddMember("LIST", firstname, lastname, company, email);

            return View();
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