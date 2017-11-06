using System.Linq;
using System.Net;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Domain.Data.Queries;
using Hdnug.Web.Areas.Admin.Models.ViewModels;
using Highway.Data;

namespace Hdnug.Web.Areas.Admin.Controllers
{
    public class MeetingsController : AdminAreaBaseController
    {
        private readonly IRepository _repo;

        public MeetingsController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: Meetings
        public ActionResult Index()
        {
            var meetings = _repo.Find(new MeetingList()).ToList();
            var viewModel = new MeetingListViewModel
            {
                Meetings = meetings
            };
            return View(viewModel);
        }

        // GET: Meetings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var meeting = _repo.Find(new GetMeetingById((int)id));
            if (meeting == null)
            {
                return HttpNotFound();
            }

            var viewModel = new MeetingViewModel(meeting);
            return View(viewModel);
        }

        // GET: Meetings/Create
        public ActionResult Create()
        {
            var sponsors = _repo.Find(new FindAll<Sponsor>()).ToList();
            var presentations = _repo.Find(new FindAll<Presentation>()).ToList();
            var locations = _repo.Find(new FindAll<Location>()).ToList();
            var viewModel = new MeetingViewModel { Sponsors = sponsors, Presentations = presentations , Locations = locations};
            return View(viewModel);
        }

        // POST: Meetings/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MeetingViewModel meetingViewModel)
        {
            if (ModelState.IsValid)
            {
                var sponsors = _repo.Find(new GetSponsorsByIds(meetingViewModel.SelectedSponsors.ToArray())).ToList();
                var presentations = _repo.Find(new GetPresentationsByIds(meetingViewModel.SelectedPresentations.ToArray())).ToList();
                var meeting = new Meeting
                {
                    Id = meetingViewModel.Id,
                    Title = meetingViewModel.Title,
                    Description = meetingViewModel.Description,
                    MeetingStartDateTime = meetingViewModel.MeetingStartDateTime,
                    MeetingEndDateTime = meetingViewModel.MeetingEndDateTime,
                    LocationId = meetingViewModel.LocationId, 
                    Sponsors = sponsors,
                    Presentations = presentations
                };
                _repo.Context.Add(meeting);
                _repo.Context.Commit();
                return RedirectToAction("Index");
            }
            meetingViewModel.Presentations = _repo.Find(new FindAll<Presentation>()).ToList();
            meetingViewModel.Sponsors = _repo.Find(new FindAll<Sponsor>()).ToList();
            meetingViewModel.Locations = _repo.Find(new FindAll<Location>()).ToList();
            return View(meetingViewModel);
        }

        // GET: Meetings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var meeting = _repo.Find(new GetMeetingById((int)id));

            if (meeting == null)
            {
                return HttpNotFound();
            }
            var sponsors = _repo.Find(new FindAll<Sponsor>()).ToList();
            var presentations = _repo.Find(new FindAll<Presentation>()).ToList();
            var meetingViewModel = new MeetingViewModel
            {
                Id = meeting.Id,
                Title = meeting.Title,
                Description = meeting.Description,
                LocationId = meeting.LocationId, 
                LocationName = meeting.Location.Name,
                MeetingStartDateTime = meeting.MeetingStartDateTime,
                MeetingEndDateTime = meeting.MeetingEndDateTime,
                Presentations = presentations,
                Sponsors = sponsors,
                Locations = _repo.Find(new FindAll<Location>()).ToList()
        };
            meetingViewModel.SelectedPresentations = (meeting.Presentations.Select(x => x.Id)).ToList();
            meetingViewModel.SelectedSponsors = meeting.Sponsors.Select(e => e.Id).ToList();

            return View(meetingViewModel);
        }

        // POST: Meetings/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MeetingViewModel meetingViewModel)
        {
            var meeting = _repo.Find(new GetMeetingById(meetingViewModel.Id));
            if (ModelState.IsValid)
            {
                meetingViewModel.ToMeeting(meeting);
                meeting.Title = meetingViewModel.Title;
                meeting.Description = meetingViewModel.Description;
                meeting.LocationId = meetingViewModel.LocationId;
                meeting.MeetingEndDateTime = meetingViewModel.MeetingEndDateTime;
                meeting.MeetingStartDateTime = meetingViewModel.MeetingStartDateTime;

                var sponsorIdsToAdd =
                    meetingViewModel.SelectedSponsors.Where(e => meeting.Sponsors.All(s => s.Id != e));
                foreach (var newSponsor in _repo.Find(new GetSponsorsByIds(sponsorIdsToAdd.ToArray())).ToArray())
                {
                    meeting.Sponsors.Add(newSponsor);
                }
                var sponsorIdsToRemove =
                    meeting.Sponsors.Where(e => meetingViewModel.SelectedSponsors.All(s => s != e.Id));
                foreach (var sponsorToRemove in sponsorIdsToRemove)
                {
                    meeting.Sponsors.Remove(sponsorToRemove);
                }

                var presentationIdsToAdd =
                    meetingViewModel.SelectedPresentations.Where(e => meeting.Presentations.All(s => s.Id != e));
                foreach (var newPresentation in _repo.Find(new GetPresentationsByIds(presentationIdsToAdd.ToArray())).ToArray())
                {
                    meeting.Presentations.Add(newPresentation);
                }
                var presentationIdsToRemove =
                    meeting.Presentations.Where(e => meetingViewModel.SelectedPresentations.All(s => s != e.Id));
                foreach (var presentationToRemove in presentationIdsToRemove)
                {
                    meeting.Presentations.Remove(presentationToRemove);
                }


                //meeting.Sponsors = sponsors;
                //meeting.Presentations = presentations;

                _repo.Context.Commit();
                return RedirectToAction("Index");
            }
            var allPresentations = _repo.Find(new FindAll<Presentation>()).ToList();
            var allSponsors = _repo.Find(new FindAll<Sponsor>()).ToList();
            meetingViewModel.Presentations = allPresentations;
            meetingViewModel.Sponsors = allSponsors;
            meetingViewModel.Locations = _repo.Find(new FindAll<Location>()).ToList();
            meetingViewModel.SelectedPresentations.AddRange(allPresentations.Select(x => x.Id).Except(meetingViewModel.SelectedPresentations));
            meetingViewModel.SelectedSponsors.AddRange(allSponsors.Select(x => x.Id).Except(meetingViewModel.SelectedSponsors));
            return View(meetingViewModel);
        }

        // POST: Meetings/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            _repo.Execute(new RemoveMeetingById(id));
            return RedirectToAction("Index");
        }
    }
}