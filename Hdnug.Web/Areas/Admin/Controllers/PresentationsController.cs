using System.Linq;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Areas.Admin.Models.ViewModels;
using Highway.Data;
using WebGrease.Css.Extensions;
using System.Collections.Generic;

namespace Hdnug.Web.Areas.Admin.Controllers
{
    public class PresentationsController : AdminAreaBaseController
    {
        private readonly IRepository _repository;
        public PresentationsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: Presentation
        public ActionResult Index()
        {
            var presentations = _repository.Find(new AllPresentations());
            var viewModel = new List<PresentationViewModel>();

            presentations.ForEach(p => viewModel.Add(new PresentationViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                PresentationStartDateTime = p.PresentationStartDateTime,
                PresentationEndDateTime = p.PresentationEndDateTime,
                Location = p.Location
            }));
          
            return View(viewModel);
        }

        // GET: Presentation/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = BuildPresentationViewModel(id);

            return View(viewModel);
        }

        // GET: Presentation/Create
        public ActionResult Create()
        {
            var speakers = _repository.Find(new FindAll<Speaker>()).OrderBy(s => s.Name).ToList();
            var viewModel = new PresentationViewModel
            {
                Speakers = speakers
            };

            return View(viewModel);
        }

        // POST: Presentation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PresentationViewModel presentationViewModel)
        {
            if (ModelState.IsValid)
            {
                var speakers = _repository.Find(new GetSpeakersByIds(presentationViewModel.SelectedSpeakers.ToArray())).ToList();
                var presentation = new Presentation
                {
                    Title = presentationViewModel.Title,
                    Description = presentationViewModel.Description,
                    PresentationStartDateTime = presentationViewModel.PresentationStartDateTime,
                    PresentationEndDateTime = presentationViewModel.PresentationEndDateTime,
                    Location = presentationViewModel.Location,
                    Speakers = speakers
                };

                _repository.Context.Add(presentation);
                _repository.Context.Commit();

                return RedirectToAction("Index");
            }
            presentationViewModel.Speakers = _repository.Find(new FindAll<Speaker>()).OrderBy(s => s.Name).ToList();
            return View(presentationViewModel);
        }

        // GET: Presentation/Edit/5
        public ActionResult Edit(int id)
        {
            var presentationViewModel = BuildPresentationViewModel(id);
            presentationViewModel.Speakers = _repository.Find(new FindAll<Speaker>()).OrderBy(s => s.Name).ToList();
            return View(presentationViewModel);
        }

        // POST: Presentation/Edit/5
        [HttpPost]
        public ActionResult Edit(PresentationViewModel presentationViewModel)
        {
            var presentation = _repository.Find(new GetPresentationById(presentationViewModel.Id));
            if (ModelState.IsValid)
            {
                var speakers = _repository.Find(new GetSpeakersByIds(presentationViewModel.SelectedSpeakers.ToArray())).ToList();
                presentation.Title = presentationViewModel.Title;
                presentation.Description = presentationViewModel.Description;
                presentation.PresentationStartDateTime = presentationViewModel.PresentationStartDateTime;
                presentation.PresentationEndDateTime = presentationViewModel.PresentationEndDateTime;
                presentation.Location = presentationViewModel.Location;
                presentation.Speakers = speakers;

                _repository.Context.Commit();

                return RedirectToAction("Index");
            }
            var allSpeakers = _repository.Find(new FindAll<Speaker>()).OrderBy(s => s.Name).ToList();
            presentationViewModel.Speakers = allSpeakers;
            presentationViewModel.SelectedSpeakers.AddRange(allSpeakers.Select(s => s.Id).Except(presentationViewModel.SelectedSpeakers));
            return View(presentationViewModel);
        }

        // GET: Presentation/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.Execute(new RemovePresentationById(id));
            return RedirectToAction("Index");
        }

        private PresentationViewModel BuildPresentationViewModel(int id)
        {
            var p = _repository.Find(new GetPresentationById(id));
            var viewModel = new PresentationViewModel
            {
                Id = p.Id,
                Title = p.Title,
                Description = p.Description,
                PresentationStartDateTime = p.PresentationStartDateTime,
                PresentationEndDateTime = p.PresentationEndDateTime,
                Location = p.Location
            };
            viewModel.SelectedSpeakers.AddRange(p.Speakers.Select(x => x.Id));
            return viewModel;
        }
    }
}
