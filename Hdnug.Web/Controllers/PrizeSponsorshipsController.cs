using System.Collections.ObjectModel;
using System.Linq;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Models.ViewModels;
using Highway.Data;
using WebGrease.Css.Extensions;

namespace Hdnug.Web.Controllers
{
    public class PrizeSponsorshipsController : Controller
    {
        private readonly IRepository _repository;
        public PrizeSponsorshipsController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: PrizeSponsorhip
        public ActionResult Index()
        {
            var viewModel = new Collection<PrizeSponsorshipViewModel>();
            var prizeSponsorships = _repository.Find(new AllPrizeSponsorships());

            prizeSponsorships.ForEach(s => viewModel.Add(new PrizeSponsorshipViewModel
            {
                Id = s.Id,
                SponsorId = s.SponsorId,
                SponsorName = s.Sponsor.Name,
                StartDate = s.StartDate,
                EndDate = s.EndDate
            }));
          
            return View(viewModel);
        }

        // GET: PrizeSponsorhip/Details/5
        public ActionResult Details(int id)
        {
            var viewModel = BuildSponsorshipViewModel(id);

            return View(viewModel);
        }

        // GET: PrizeSponsorhip/Create
        public ActionResult Create()
        {
            var sponsors = _repository.Find(new FindAll<Sponsor>()).OrderBy(s => s.Name);
            var viewModel = new PrizeSponsorshipViewModel
            {
                Sponsors = sponsors
            };

            return View(viewModel);
        }

        // POST: PrizeSponsorhip/Create
        [HttpPost]
        public ActionResult Create(PrizeSponsorshipViewModel prizeSponsorshipViewModel)
        {
            if (ModelState.IsValid)
            {
                var sponsor = _repository.Find(new GetSponsorById(prizeSponsorshipViewModel.SponsorId));
                var prizeSponsorhip = new PrizeSponsorship
                {
                    Sponsor = sponsor,
                    StartDate = prizeSponsorshipViewModel.StartDate,
                    EndDate = prizeSponsorshipViewModel.EndDate
                };

                _repository.Context.Add(prizeSponsorhip);
                _repository.Context.Commit();

                return RedirectToAction("Index");
            }

            return View(prizeSponsorshipViewModel);
        }

        // GET: PrizeSponsorhip/Edit/5
        public ActionResult Edit(int id)
        {
            var viewModel = BuildSponsorshipViewModel(id);
            return View(viewModel);
        }

        // POST: PrizeSponsorhip/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PrizeSponsorshipViewModel prizeSponsorshipViewModel)
        {
            if (ModelState.IsValid)
            {
                var prizeSponsorship = _repository.Find(new GetPrizeSponsorhipById(id));

                prizeSponsorship.SponsorId = prizeSponsorshipViewModel.SponsorId;
                prizeSponsorship.StartDate = prizeSponsorshipViewModel.StartDate;
                prizeSponsorship.EndDate = prizeSponsorshipViewModel.EndDate;

                _repository.Context.Commit();

                return RedirectToAction("Index");
            }
            return View(prizeSponsorshipViewModel);
        }

        // GET: PrizeSponsorhip/Delete/5
        public ActionResult Delete(int id)
        {
            _repository.Execute(new RemovePrizeSponsorshipById(id));
            return RedirectToAction("Index");
        }

        private PrizeSponsorshipViewModel BuildSponsorshipViewModel(int id)
        {
            var prizeSponsorhip = _repository.Find(new GetPrizeSponsorhipById(id));
            var viewModel = new PrizeSponsorshipViewModel
            {
                Id = prizeSponsorhip.Id,
                SponsorId = prizeSponsorhip.SponsorId,
                SponsorName = prizeSponsorhip.Sponsor.Name,
                StartDate = prizeSponsorhip.StartDate,
                EndDate = prizeSponsorhip.EndDate
            };
            return viewModel;
        }
    }
}
