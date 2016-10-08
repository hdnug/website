using System.Web.Mvc;
using FluentAssertions;
using Hdnug.Web.Models.ViewModels;
using Highway.Data;
using Hdnug.Web.Controllers;
using NSubstitute;
using NUnit.Framework;

namespace Hdnug.Web.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        private IRepository _repo;

        [SetUp]
        public void Setup()
        {
            _repo = Substitute.For<IRepository>();
        }

        [Test]
        public void Index()
        {
            // Arrange
            var controller = new HomeController(_repo, null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void IndexViewResultShouldReturnAViewModel()
        {
            // Arrange 
            var controller = new HomeController(_repo, null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            result.Model.Should().BeOfType<HomeViewModel>();
        }

        [Test]
        public void About()
        {
            // Arrange
            var controller = new HomeController(_repo, null);

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        }

        [Test]
        public void Contact()
        {
            // Arrange
            var controller = new HomeController(_repo, null);

            // Act
            var result = controller.Contact() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
