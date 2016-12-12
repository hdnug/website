using System.Linq;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Models.ViewModels;
using Highway.Data;
using Hdnug.Web.Inrastructure.Interfaces;
using System;

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
            var meetings = _repo.Find(new LastTenMeetings()).ToList();
            var presentationCount = meetings.Select(x => x.Presentations).Count();
            var sliderImages = _repo.Find(new AllSliderImages()).ToList();
            var prizeSponsors = _repo.Find(new ActivePrizeSponsors()).ToList();
            var currentMonthMeetings = meetings.Where(x => x.MeetingStartDateTime.Month == DateTime.Today.Month && x.MeetingStartDateTime.Year == DateTime.Today.Year);
            var sponsors = currentMonthMeetings.SelectMany(x => x.Sponsors);
            var viewModel = new HomeViewModel
            {
                PresentationCount = presentationCount,
                Meetings = meetings,
                SliderImages = sliderImages,
                Sponsors = sponsors,
                PrizeSponsors = prizeSponsors
            };
             
            return View(viewModel);
        }

        public ActionResult UpcomingMeetings()
        {
            var meetings = _repo.Find(new UpcomingMeetings()).ToList();
            var presentationCount = meetings.Select(x => x.Presentations).Count();
            var viewModel = new MeetingListViewModel
            {
                PresentationCount = presentationCount,
                Meetings = meetings,
            };

            return View(viewModel);
        }

        public ActionResult PastMeetings()
        {
            var meetings = _repo.Find(new PastMeetings()).ToList();
            var presentationCount = meetings.Select(x => x.Presentations).Count();
            var viewModel = new MeetingListViewModel
            {
                PresentationCount = presentationCount,
                Meetings = meetings,
            };

            return View(viewModel);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Mailinglist(string email)
        {
            // TODO: Validate email address and handle negative cases.
            var emailAddress = email.Trim();
            var isExistingMember = _repo.Find(new GetMemberByEmailAddress(emailAddress)) != null;

            // Add member to hdnug database if not existing member.
            if(!isExistingMember)
            {
                _repo.Execute(new AddMember(email));
            }

            // Add to Announcements Mailing List. 
            // Note: If user isExistingMember the mailingListService will update the existing member.
            _mailingListService.AddMember("Announcements", email);
            return View();
        }
    }
}