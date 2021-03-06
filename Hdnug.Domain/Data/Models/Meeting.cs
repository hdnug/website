﻿using System;
using System.Collections.Generic;
using Highway.Data;

namespace Hdnug.Domain.Data.Models
{
    public class Meeting : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime MeetingStartDateTime { get; set; }
        public DateTime MeetingEndDateTime { get; set; }

        public Location Location { get; set; }

        public int LocationId { get; set; }

        public ICollection<Sponsor> Sponsors { get; set; }
        public ICollection<Presentation> Presentations { get; set; } 
    }
}