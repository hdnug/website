using System;
using System.Collections.Generic;
using Hdnug.Domain.Data.Models;
using System.ComponentModel;

namespace Hdnug.Web.Areas.Admin.Models.ViewModels
{
    // TODO: Run migrations!
    public class MeetingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime MeetingStartDateTime { get; set; } = DateTime.Today;
        public DateTime MeetingEndDateTime { get; set; } = DateTime.Today;
        public string Location { get; set; }
        public int[] SelectedSponsors { get; set; }
        public int[] SelectedPresentations { get; set; }

        public ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
        public ICollection<Presentation> Presentations { get; set; } = new List<Presentation>(); 
    }
}