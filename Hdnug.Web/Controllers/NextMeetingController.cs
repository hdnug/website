using System.Web.Mvc;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Models.ViewModels;
using Highway.Data;

namespace Hdnug.Web.Controllers
{
    public class NextMeetingController : Controller
    {
        private readonly IRepository _repository;

        public NextMeetingController(IRepository repository)
        {
            _repository = repository;
        }

        public PartialViewResult NextMeeting()
        {
            var viewModel = new NextMeetingViewModel
            {
                Meeting = _repository.Find(new GetNextMeeting())
            };

            return PartialView("_NextMeeting", viewModel);
        }
    }
}