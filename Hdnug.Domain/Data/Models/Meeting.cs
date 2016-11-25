using System;
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
        public string LocationName { get; set; }
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationCity { get; set; }
        public string LocationState { get; set; }
        public string LocationZip { get; set; }

        public ICollection<Sponsor> Sponsors { get; set; }
        public ICollection<Presentation> Presentations { get; set; } 
    }
}