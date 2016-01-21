using Hdnug.Domain.Data.Models;
using Hdnug.Domain.Data.Models.Queries;
using Hdnug.Web.Controllers;
using Highway.Data;
using NSubstitute;
using NUnit.Framework;

namespace Hdnug.Web.Tests.Controllers
{
    [TestFixture]
    public class NextMeetingControllerTests
    {
        [Test]
        public void IndexShouldReturnNextMeeting()
        {
            // Arrange
            var repo = Substitute.For<IRepository>();
            var controller = new NextMeetingController(repo);
            repo.Find(new GetNextMeeting()).Returns(new Meeting());

            // Act
            controller.NextMeeting();

            // Assert
            Assert.AreEqual(repo.Find(new GetNextMeeting()), controller.ViewBag.Meeting);
        }
    }
}