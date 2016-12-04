using System;
using System.Collections.Generic;
using Hdnug.Domain.Data.Models;
using System.ComponentModel;

namespace Hdnug.Web.Areas.Admin.Models.ViewModels
{
    public class MeetingViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime MeetingStartDateTime { get; set; } = DateTime.Today.AddHours(18).AddMinutes(30);
        public DateTime MeetingEndDateTime { get; set; } = DateTime.Today.AddHours(20).AddMinutes(30);
        public string LocationName { get; set; } = "Microsoft Technology Center - Houston";
        public string LocationAddress1 { get; set; } = "Suite 1000";
        public string LocationAddress2 { get; set; } = "750 Town and Country Blvd.";
        public string LocationCity { get; set; } = "Houston";
        public string LocationState { get; set; } = "TX";
        public string LocationZip { get; set; } = "77024";
        public List<int> SelectedSponsors { get; set; } = new List<int>();
        public List<int> SelectedPresentations { get; set; } = new List<int>();

        public ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
        public ICollection<Presentation> Presentations { get; set; } = new List<Presentation>(); 
    }
}