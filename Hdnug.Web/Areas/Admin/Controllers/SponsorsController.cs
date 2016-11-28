using System.Collections.Generic;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Inrastructure;
using Hdnug.Web.Interfaces;
using Hdnug.Web.Areas.Admin.Models.ViewModels;
using Highway.Data;
using WebGrease.Css.Extensions;

namespace Hdnug.Web.Areas.Admin.Controllers
{
    public class SponsorsController : AdminAreaBaseController
    {
        private readonly IRepository _repository;
        private readonly IProvideServerMapPath _serverMapPathProvider;
        public SponsorsController(IRepository repository, IProvideServerMapPath serverMapPathProvider)
        {
            _repository = repository;
            _serverMapPathProvider = serverMapPathProvider;
        }

        // GET: Sponsors
        public ActionResult Index()
        {
            var sponsors = _repository.Find(new AllSponsors());
            var sponsorsViewModel = new List<SponsorViewModel>();

            sponsors.ForEach(x =>
            {
                var sponsor = new SponsorViewModel
                {
                    Id = x.Id,
                    Contact = x.Contact,
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                    SponsorMessage = x.SponsorMessage,
                    WebSiteUrl = x.WebSiteUrl,
                    LogoUrl = x.Logo != null ? x.Logo.ImageUrl : string.Empty,
                    TagLine = x.TagLine
                };
                sponsorsViewModel.Add(sponsor);
            });

            return View(sponsorsViewModel);
        }

        // GET: Sponsors/Details/5
        public ActionResult Details(int id)
        {
            var sponsor = _repository.Find(new GetSponsorById(id));
            var viewModel = new SponsorViewModel
            {
                Id = sponsor.Id,
                Contact = sponsor.Contact,
                Email = sponsor.Email,
                Name = sponsor.Name,
                Phone = sponsor.Phone,
                TagLine = sponsor.TagLine,
                SponsorMessage = sponsor.SponsorMessage,
                WebSiteUrl = sponsor.WebSiteUrl,
                LogoUrl = sponsor.Logo != null ? sponsor.Logo.ImageUrl : string.Empty,
            };
            return View(viewModel);
        }

        // GET: Sponsors/Create
        public ActionResult Create()
        {
            return View(new SponsorViewModel());
        }

        // POST: Sponsors/Create
        [HttpPost]
        public ActionResult Create(SponsorViewModel sponsorViewModel)
        {
            var imageInfo = sponsorViewModel.Name + " Logo";
            var imageValidation = sponsorViewModel.Logo.ValidateImageUpload();

            if (imageValidation.ContainsKey("ModelError"))
            {
                ModelState.AddModelError("ImageUpload", imageValidation["ModelError"]);
            }

            if (ModelState.IsValid)
            {
                var sponsor = new Sponsor
                {
                    Contact = sponsorViewModel.Contact,
                    Email = sponsorViewModel.Email,
                    Name = sponsorViewModel.Name,
                    Phone = sponsorViewModel.Phone,
                    TagLine = sponsorViewModel.TagLine,
                    SponsorMessage = sponsorViewModel.SponsorMessage,
                    WebSiteUrl = sponsorViewModel.WebSiteUrl
                };
                var url = sponsorViewModel.Logo.SaveImageUpload(_serverMapPathProvider, Constants.SponsorUploadDir);
                var logo = new Image { Title = imageInfo, AltText = imageInfo, ImageType = ImageType.Logo, ImageUrl = url };
                sponsor.Logo = logo;
                _repository.Context.Add(sponsor);
                _repository.Context.Commit();

                return RedirectToAction("Index");
            }
            return View(sponsorViewModel);
        }

        // GET: Sponsors/Edit/5
        public ActionResult Edit(int id)
        {
            var sponsor = _repository.Find(new GetSponsorById(id));
            var viewModel = new SponsorViewModel
            {
                Contact = sponsor.Contact,
                Email = sponsor.Email,
                Name = sponsor.Name,
                Phone = sponsor.Phone,
                TagLine = sponsor.TagLine,
                SponsorMessage = sponsor.SponsorMessage,
                WebSiteUrl = sponsor.WebSiteUrl,
                LogoId = sponsor.Logo != null ? sponsor.Logo.Id : 0,
                LogoUrl = sponsor.Logo?.ImageUrl
            };
            return View(viewModel);
        }

        // POST: Sponsors/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SponsorViewModel sponsorViewModel)
        {
            var imageInfo = sponsorViewModel.Name + " Logo";

            if (sponsorViewModel.Logo != null)
            {
                var imageValidation = sponsorViewModel.Logo.ValidateImageUpload();
                if (imageValidation.ContainsKey("ModelError"))
                {
                    ModelState.AddModelError("ImageUpload", imageValidation["ModelError"]);
                }
            }

            if (ModelState.IsValid)
            {
                var sponsor = _repository.Find(new GetSponsorById(id));

                sponsor.Contact = sponsorViewModel.Contact;
                sponsor.Email = sponsorViewModel.Email;
                sponsor.Name = sponsorViewModel.Name;
                sponsor.Phone = sponsorViewModel.Phone;
                sponsor.TagLine = sponsorViewModel.TagLine;
                sponsor.SponsorMessage = sponsorViewModel.SponsorMessage;
                sponsor.WebSiteUrl = sponsorViewModel.WebSiteUrl;

                // Get existing image from database. 
                var image = _repository.Find(new GetById<int, Image>(sponsorViewModel.LogoId));

                // If image is cleared then we delete the image from the image store and set the sponsor logo to null
                if (sponsorViewModel.ImageIsCleared)
                {
                    if (image != null)
                    {
                        image.DeleteImage(_serverMapPathProvider, Constants.SponsorUploadDir);
                    }
                    image = null;
                }

                // Set image from viewModel. If the logo on the viewModel is not null then the user
                // has changed the image from the screen so we overwrite the image retrieved from the database
                if (sponsorViewModel.Logo != null)
                {
                    var url = sponsorViewModel.Logo.SaveImageUpload(_serverMapPathProvider, Constants.SponsorUploadDir);
                    var newImage = new Image { Title = imageInfo, AltText = imageInfo, ImageType = ImageType.Profile, ImageUrl = url };
                    if (image != null)
                    {
                        image.DeleteImage(_serverMapPathProvider, Constants.SponsorUploadDir);
                    }
                    image = newImage;
                }

                // Set speaker photo to the existing image, no image, or the new image
                sponsor.Logo = image;

                _repository.Context.Commit();

                return RedirectToAction("Index");
            }
            return View(sponsorViewModel);
        }

        // GET: Sponsors/Delete/5
        public ActionResult Delete(int id)
        {
            
            var sponsor = _repository.Find(new GetSponsorById(id));

            // TODO: Extension method should return error message when file could not be found or deleted
            sponsor.Logo.DeleteImage(_serverMapPathProvider, Constants.SponsorUploadDir);

            if (true)
            {
                _repository.Execute(new RemoveSponsorById(id));
            }
            
            return RedirectToAction("Index");

        }
    }
}
