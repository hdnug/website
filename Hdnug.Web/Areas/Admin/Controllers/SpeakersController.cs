using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
    public class SpeakersController : AdminAreaBaseController
    {
        private readonly IRepository _repository;
        private readonly IProvideServerMapPath _serverMapPathProvider;
        public SpeakersController(IRepository repository, IProvideServerMapPath serverMapPathProvider)
        {
            _repository = repository;
            _serverMapPathProvider = serverMapPathProvider;
        }

        // GET: Speakers
        public ActionResult Index()
        {
            var Speakers = _repository.Find(new AllSpeakers());
            var SpeakersViewModel = new List<SpeakerViewModel>();

            Speakers.ForEach(x =>
            {
                var speaker = new SpeakerViewModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    Name = x.Name,
                    Phone = x.Phone,
                    WebSiteUrl = x.WebSiteUrl,
                    PhotoUrl = x.Photo != null ? x.Photo.ImageUrl : string.Empty,
                    Bio = x.Bio
                };
                SpeakersViewModel.Add(speaker);
            });

            return View(SpeakersViewModel);
        }

        // GET: Speakers/Details/5
        public ActionResult Details(int id)
        {
            var speaker = _repository.Find(new GetSpeakerById(id));
            var viewModel = new SpeakerViewModel
            {
                Id = speaker.Id,
                Email = speaker.Email,
                Name = speaker.Name,
                Phone = speaker.Phone,
                WebSiteUrl = speaker.WebSiteUrl,
                PhotoUrl = speaker.Photo.ImageUrl,
                Bio = speaker.Bio
            };
            return View(viewModel);
        }

        // GET: Speakers/Create
        public ActionResult Create()
        {
            return View(new SpeakerViewModel());
        }

        // POST: Speakers/Create
        [HttpPost]
        public ActionResult Create(SpeakerViewModel SpeakerViewModel)
        {
            var imageInfo = SpeakerViewModel.Name + " Photo";
            var imageValidation = SpeakerViewModel.Photo.ValidateImage();

            if (SpeakerViewModel.Photo.ValidateImageUpload().ContainsKey("ModelError"))
            {
                ModelState.AddModelError("ImageUpload", imageValidation["ModelError"]);
            }

            if (ModelState.IsValid)
            {
                var speaker = new Speaker
                {
                    Email = SpeakerViewModel.Email,
                    Name = SpeakerViewModel.Name,
                    Phone = SpeakerViewModel.Phone,
                    WebSiteUrl = SpeakerViewModel.WebSiteUrl,
                    Bio = SpeakerViewModel.Bio
                };
                var url = SpeakerViewModel.Photo.SaveImageUpload(_serverMapPathProvider, Constants.SponsorUploadDir);
                var Photo = new Image { Title = imageInfo, AltText = imageInfo, ImageType = ImageType.Profile, ImageUrl = url };
                speaker.Photo = Photo;
                _repository.Context.Add(speaker);
                _repository.Context.Commit();

                return RedirectToAction("Index");
            }
            return View(SpeakerViewModel);
        }

        // GET: Speakers/Edit/5
        public ActionResult Edit(int id)
        {
            var speaker = _repository.Find(new GetSpeakerById(id));
            var viewModel = new SpeakerViewModel
            {
                Email = speaker.Email,
                Name = speaker.Name,
                Phone = speaker.Phone,
                WebSiteUrl = speaker.WebSiteUrl,
                PhotoUrl = speaker.Photo.ImageUrl,
                Bio = speaker.Bio
            };
            return View(viewModel);
        }

        // POST: Speakers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SpeakerViewModel SpeakerViewModel)
        {
            var imageInfo = SpeakerViewModel.Name + " Photo";
            var imageValidation = SpeakerViewModel.Photo.ValidateImage();

            if (SpeakerViewModel.Photo.ValidateImageUpload().ContainsKey("ModelError"))
            {
                ModelState.AddModelError("ImageUpload", imageValidation["ModelError"]);
            }

            if (ModelState.IsValid)
            {
                var url = SpeakerViewModel.Photo.SaveImageUpload(_serverMapPathProvider, Constants.SponsorUploadDir);
                var Photo = new Image { Title = imageInfo, AltText = imageInfo, ImageType = ImageType.Profile, ImageUrl = url };
                var speaker = _repository.Find(new GetSpeakerById(id));

                speaker.Email = SpeakerViewModel.Email;
                speaker.Name = SpeakerViewModel.Name;
                speaker.Phone = SpeakerViewModel.Phone;
                speaker.WebSiteUrl = SpeakerViewModel.WebSiteUrl;
                speaker.Photo = Photo;
                speaker.Bio = SpeakerViewModel.Bio;

                _repository.Context.Commit();

                return RedirectToAction("Index");
            }
            return View(SpeakerViewModel);
        }

        // GET: Speakers/Delete/5
        public ActionResult Delete(int id)
        {
            
            var speaker = _repository.Find(new GetSpeakerById(id));

            // TODO: Extension method should return error message when file could not be found or deleted
            speaker.Photo.DeleteImage(_serverMapPathProvider, Constants.SponsorUploadDir, speaker.Photo.ImageUrl);

            if (true)
            {
                _repository.Execute(new RemoveSponsorById(id));
            }
            
            return RedirectToAction("Index");

        }
    }
}
