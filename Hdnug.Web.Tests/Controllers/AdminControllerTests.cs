using System.Web.Mvc;
using Hdnug.Web.Controllers;
using NUnit.Framework;

namespace Hdnug.Web.Tests.Controllers
{
    [TestFixture]
    public class AdminControllerTests
    {
        [Test]
        public void ShouldReturnViewResult()
        {
            // Arrange
            var controller = new AdminController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}