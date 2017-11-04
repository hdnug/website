using System;
using System.Collections.Generic;
using Hdnug.Domain.Data.Models;
using System.ComponentModel;

namespace Hdnug.Web.Areas.Admin.Models.ViewModels
{
    public class MeetingViewModel
    {
        public MeetingViewModel()
        {
            
        }

        public MeetingViewModel(Meeting meeting)
        {
            Id = meeting.Id;
            Title = meeting.Title;
            Description = meeting.Description;
            MeetingStartDateTime = meeting.MeetingStartDateTime;
            MeetingEndDateTime = meeting.MeetingEndDateTime;
            LocationId = meeting.LocationId;
            LocationName = meeting.Location.Name;
        }

        public Meeting ToMeeting(Meeting meeting)
        {
            meeting.Title = Title;
            meeting.Description = Description;
            meeting.LocationId = LocationId;
            meeting.MeetingEndDateTime = MeetingEndDateTime;
            meeting.MeetingStartDateTime = MeetingStartDateTime;
            meeting.Sponsors = Sponsors;
            meeting.Presentations = Presentations;
            return meeting; 

        }

        public Meeting ToMeeting()
        {
            var meeting = new Meeting();
            return ToMeeting(meeting);
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime MeetingStartDateTime { get; set; } = DateTime.Today.AddHours(18).AddMinutes(30);
        public DateTime MeetingEndDateTime { get; set; } = DateTime.Today.AddHours(20).AddMinutes(30);
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public List<int> SelectedSponsors { get; set; } = new List<int>();
        public List<int> SelectedPresentations { get; set; } = new List<int>();

        public ICollection<Sponsor> Sponsors { get; set; } = new List<Sponsor>();
        public ICollection<Presentation> Presentations { get; set; } = new List<Presentation>(); 

        public ICollection<Location> Locations { get; set; }
    }
}