using System;
using System.Collections.Generic;
using Hdnug.Domain.Data.Models;

namespace Hdnug.Web.Models.ViewModels
{
    // TODO: Run migrations!
    public class MeetingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime MeetingStartDateTime { get; set; }
        public DateTime MeetingEndDateTime { get; set; }
        public string Location { get; set; }

        public virtual ICollection<Sponsor> Sponsors { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }  
    }
}