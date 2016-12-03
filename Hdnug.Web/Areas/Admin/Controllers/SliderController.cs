using System.Web.Mvc;
using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Inrastructure;
using Hdnug.Web.Interfaces;
using Hdnug.Web.Areas.Admin.Models.ViewModels;
using Highway.Data;

namespace Hdnug.Web.Areas.Admin.Controllers
{
    public class SliderController : AdminAreaBaseController
    {
        private readonly IRepository _repo;
        private readonly IProvideServerMapPath _serverMapPathProvider;

        public SliderController(IRepository repo, IProvideServerMapPath serverMapPathProvider)
        {
            _repo = repo;
            _serverMapPathProvider = serverMapPathProvider;
        }

        public ViewResult Index()
        {
            var viewModel = new ImageViewModel()
            {
                Images = _repo.Find(new AllSliderImages())
            };

            return View(viewModel);
        }

        public ViewResult Create()
        {
            return View(new ImageViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ImageViewModel imageViewModel)
        {
            var imageValidation = imageViewModel.ImageUpload.ValidateImageUpload();

            if (imageValidation.ContainsKey("ModelError"))
            {
                ModelState.AddModelError("ImageUpload", imageValidation["ModelError"]);
            }

            if (ModelState.IsValid)
            {
                var url = imageViewModel.ImageUpload.SaveImageUpload(_serverMapPathProvider, Constants.SiteUploadDir);
                imageViewModel.Image.ImageUrl = url;
                imageViewModel.Image.ImageType = ImageType.Slider;

                _repo.Context.Add(imageViewModel.Image);
                _repo.Context.Commit();

                return RedirectToAction("Index");
            }

            return View(imageViewModel);   
        }

        public ActionResult Delete(ImageViewModel imageViewModel)
        {
            _repo.Execute(new RemoveSliderById(imageViewModel.Id));
            return RedirectToAction("Index");
        }
    }
}