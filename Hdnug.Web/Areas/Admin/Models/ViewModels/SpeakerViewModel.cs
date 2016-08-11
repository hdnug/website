using Hdnug.Domain.Data.Models;
using System.Collections.Generic;
using System.Web;

namespace Hdnug.Web.Areas.Admin.Models.ViewModels
{
    public class SpeakerViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string WebSiteUrl { get; set; }
        public string PhotoUrl { get; set; }

        public HttpPostedFileBase Photo { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }
    }
}