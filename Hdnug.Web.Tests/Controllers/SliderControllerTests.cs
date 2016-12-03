using System.IO;
using System.Linq;
using System.Web;
using FluentAssertions;
using Hdnug.Domain.Data.Models;
using Hdnug.Web.Controllers;
using Hdnug.Web.Interfaces;
using Hdnug.Web.Models.ViewModels;
using Highway.Data;
using Highway.Data.Contexts;
using NSubstitute;
using NUnit.Framework;

namespace Hdnug.Web.Tests.Controllers
{
    using Hdnug.Web.Areas.Admin.Controllers;
    using Hdnug.Web.Areas.Admin.Models.ViewModels;
    using System.Web.Mvc;

    [TestFixture]
    public class SliderControllerTests
    {
        private IProvideServerMapPath _mapPathProvider;
        private IRepository _repo;
        private IDataContext _context;
        private SliderController _controller;
        private ImageViewModel _imageViewModel;
        private HttpPostedFileBase _imageUpload;

        [SetUp]
        public void Setup()
        {
            _mapPathProvider = Substitute.For<IProvideServerMapPath>();
            _repo = Substitute.For<IRepository>();
            _context = new InMemoryDataContext();
            _repo.Context.Returns(_context);
            _controller = new SliderController(_repo, _mapPathProvider);
            _imageViewModel = new ImageViewModel();
            _imageUpload = Substitute.For<HttpPostedFileBase>();
        }

        [Test]
        public void ShouldReturnIndex()
        {
            // Act
            var result = _controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void ShouldReturnCreate()
        {
            // Act
            var result = _controller.Create();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void CreateShouldReturnImageViewModel()
        {
            // Act
            var result = _controller.Create();

            // Assert
            result.Model.Should().BeOfType<ImageViewModel>();
        }

        [Test]
        public void CreateShouldAddModelErrorIfImageIsNull()
        {
            // Act
            var result = (ViewResult)_controller.Create(_imageViewModel);

            // Assert
            Assert.IsNotNull(result.ViewData.ModelState["ImageUpload"].Errors);
        }

        [Test]
        public void CreateShouldAddModelErrorIfNotValidImageType()
        {

            // Arrange
            _imageUpload.ContentType.Returns(".docx");
            _imageViewModel.ImageUpload = _imageUpload;

            // Act
            var result = (ViewResult)_controller.Create(_imageViewModel);

            // Assert
            Assert.IsNotNull(result.ViewData.ModelState["ImageUpload"].Errors);
        }

        [Test]
        public void CreateShouldSaveImage()
        {
            // Arrange
            var str = "input";
            var buffer = System.Text.Encoding.UTF8.GetBytes(str);
            var stream = new MemoryStream(buffer);
            var imgUrl = "~/Content/Images/Site/TestFile.jpeg";

            _imageUpload.ContentLength.Returns(1024);
            _imageUpload.ContentType.Returns("image/jpeg");
            _imageUpload.FileName.Returns("TestFile.jpeg");
            _imageUpload.InputStream.Returns(stream);
            _imageViewModel.ImageUpload = _imageUpload;
            _imageViewModel.Image = new Image();

            // Act
            _controller.Create(_imageViewModel);

            // Assert
            var query = new FindAll<Image>();
            var slider = query.Execute(_context).First();

            Assert.IsTrue(slider.ImageUrl == imgUrl);
        }
    }
}