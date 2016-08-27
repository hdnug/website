using System.Web.Mvc;
using Hdnug.Domain.Constants;

namespace Hdnug.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = Roles.ApplicationAdministrator)]
    public class AdminAreaBaseController : Controller
    {
    }
}