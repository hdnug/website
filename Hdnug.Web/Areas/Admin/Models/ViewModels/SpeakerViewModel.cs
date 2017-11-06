using System;
using Hdnug.Domain.Data.Models;
using System.Collections.Generic;
using System.Web;

namespace Hdnug.Web.Areas.Admin.Models.ViewModels
{
    public class SpeakerViewModel
    {
        public SpeakerViewModel()
        {
           
        }


        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        
        public string Name => FirstName + " " + LastName;
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string WebSiteUrl { get; set; }
        public int PhotoId { get; set; }
        public string PhotoUrl { get; set; }
        public bool ImageIsCleared { get; set; }

        public HttpPostedFileBase Photo { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }
    }
}