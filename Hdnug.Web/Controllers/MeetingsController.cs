using System.Web.Mvc;
using Hdnug.Domain.Data.Models.Queries;
using Highway.Data;
using System.Linq;
using Hdnug.Web.Models.ViewModels;

namespace Hdnug.Web.Controllers
{
    public class MeetingsController : Controller
    {
        private IRepository _repository;

        public MeetingsController(IRepository repository)
        {
            this._repository = repository;
        }

        // GET: Meetings
        public ActionResult Index()
        {
            return View();
        }

        // GET: Upcoming Meetings
        public ActionResult Upcoming()
        {
            return View();
        }

        [Route("Meeting/{meetingId:int}/Presentation/{id:int}")]
        public ActionResult Details(int meetingId, int id)
        {
            var meeting = _repository.Find(new GetMeetingById(meetingId));
            var presentation = meeting.Presentations.Single(x => x.Id == id);
            var sponsors = meeting.Sponsors.ToList();
            var prizeSponsors = _repository.Find(new ActivePrizeSponsors()).ToList();
            var meetingDetailsViewModel = new MeetingDetailsViewModel
            {
                Meeting = meeting,
                Presentation = presentation,
                Sponsors = sponsors,
                PrizeSponsors = prizeSponsors
            };
            return View(meetingDetailsViewModel);
        }
    }
}