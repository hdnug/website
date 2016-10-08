using System.Web.Mvc;
using Hdnug.Domain.Data.Models.Queries;
using Highway.Data;

namespace Hdnug.Web.Controllers
{
    [RoutePrefix("Meeting")]
    public class MeetingController : Controller
    {
        private IRepository _repository;

        public MeetingController(IRepository repository)
        {
            this._repository = repository;
        }

        // GET: Meeting
        [Route("{id}")]
        public ActionResult Index(int id)
        {
            var meeting = _repository.Find(new GetMeetingDetailsById(id));
            return View(meeting);
        }
    }
}