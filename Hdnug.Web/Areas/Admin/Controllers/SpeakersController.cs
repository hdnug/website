using System.Collections.Generic;
using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Domain.Extensions;
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
            var speakers = _repository.Find(new AllSpeakers());
            var viewModel = new List<SpeakerViewModel>();

            speakers.ForEach(x =>
            {
                var speaker = new SpeakerViewModel
                {
                    Id = x.Id,
                    Email = x.Email,
                    FirstName = x.FirstName, 
                    LastName = x.LastName, 
                    Phone = x.Phone,
                    WebSiteUrl = x.WebSiteUrl,
                    PhotoUrl = x.Photo != null ? x.Photo.ImageUrl : string.Empty,
                    Bio = x.Bio
                };
                viewModel.Add(speaker);
            });

            return View(viewModel);
        }

        // GET: Speakers/Details/5
        public ActionResult Details(int id)
        {
            var speaker = _repository.Find(new GetSpeakerById(id));
            var viewModel = new SpeakerViewModel
            {
                Id = speaker.Id,
                Email = speaker.Email,
                Phone = speaker.Phone,
                WebSiteUrl = speaker.WebSiteUrl,
                PhotoUrl = speaker.Photo != null ? speaker.Photo.ImageUrl : string.Empty,
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
            var imageValidation = SpeakerViewModel.Photo.ValidateImageUpload();

            if (imageValidation.ContainsKey("ModelError"))
            {
                ModelState.AddModelError("ImageUpload", imageValidation["ModelError"]);
            }

            if (ModelState.IsValid)
            {
                var speaker = new Speaker
                {
                    Email = SpeakerViewModel.Email,
                    FirstName = SpeakerViewModel.FirstName, 
                    LastName = SpeakerViewModel.LastName,
                    
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
                FirstName = speaker.FirstName, 
                LastName = speaker.LastName, 
                Email = speaker.Email,
                Phone = speaker.Phone,
                WebSiteUrl = speaker.WebSiteUrl,
                PhotoId = speaker.Photo != null ? speaker.Photo.Id : 0,
                PhotoUrl = speaker.Photo?.ImageUrl,
                Bio = speaker.Bio, 
                ImageSize = speaker.Photo.ScaleImage(150, 150)
            };
            return View(viewModel);
        }

        // POST: Speakers/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SpeakerViewModel speakerViewModel)
        {
            var imageInfo = speakerViewModel.Name + " Photo";
            
            if(speakerViewModel.Photo != null)
            {
                var imageValidation = speakerViewModel.Photo.ValidateImageUpload();
                if (imageValidation.ContainsKey("ModelError"))
                {
                    ModelState.AddModelError("ImageUpload", imageValidation["ModelError"]);
                }
            }

            if (!ModelState.IsValid) return View(speakerViewModel);

            var speaker = _repository.Find(new GetSpeakerById(id));
            speaker.Email = speakerViewModel.Email;
            speaker.FirstName = speakerViewModel.FirstName;
            speaker.LastName = speakerViewModel.LastName;
            speaker.Phone = speakerViewModel.Phone;
            speaker.WebSiteUrl = speakerViewModel.WebSiteUrl;
            speaker.Bio = speakerViewModel.Bio;

            // Get existing image from database. 
            var image = _repository.Find(new GetById<int, Image>(speakerViewModel.PhotoId));

            // If image is cleared then we delete the image from the image store and set the speaker photo to null
            if (speakerViewModel.ImageIsCleared)
            {
                image?.DeleteImage(_serverMapPathProvider, Constants.SpeakerUploadDir);
                image = null;
            }

            // Set image from viewModel. If the photo on the viewModel is not null then the user
            // has changed the image from the screen so we overwrite the image retrieved from the database
            if(speakerViewModel.Photo != null)
            {
                var url = speakerViewModel.Photo.SaveImageUpload(_serverMapPathProvider, Constants.SpeakerUploadDir, "speaker." + id.ToString());
                //load the image. 

                var img = System.Drawing.Image.FromStream(speakerViewModel.Photo.InputStream);
                var newImage = new Image { Title = imageInfo, AltText = imageInfo, ImageType = ImageType.Profile, ImageUrl = url,
                    Height = img.Height, Width = img.Width, Caption = speaker.Name}; 
                image = newImage;
            }
                
            // Set speaker photo to the existing image, no image, or the new image
            speaker.Photo = image;

            _repository.Context.Commit();

            return RedirectToAction("Index");
        }

        // GET: Speakers/Delete/5
        public ActionResult Delete(int id)
        {
            var speaker = _repository.Find(new GetSpeakerById(id));

            speaker.Photo.DeleteImage(_serverMapPathProvider, Constants.SponsorUploadDir);

            if (true)
            {
                _repository.Execute(new RemoveSponsorById(id));
            }
            
            return RedirectToAction("Index");
        }
    }
}
