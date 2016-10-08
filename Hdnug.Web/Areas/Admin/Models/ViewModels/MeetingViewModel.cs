﻿using System;
using System.Collections.Generic;
using Hdnug.Domain.Data.Models;
using System.ComponentModel;

namespace Hdnug.Web.Areas.Admin.Models.ViewModels
{
    // TODO: Run migrations!
    public class MeetingViewModel
    {
        public MeetingViewModel()
        {
            Sponsors = new List<Sponsor>();
            Presentations = new List<Presentation>();
        }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime MeetingStartDateTime { get; set; }
        public DateTime MeetingEndDateTime { get; set; }
        public string Location { get; set; }
        public int[] SelectedSponsors { get; set; }
        public int[] SelectedPresentations { get; set; }

        public ICollection<Sponsor> Sponsors { get; set; }
        public ICollection<Presentation> Presentations { get; set; }  
    }
}