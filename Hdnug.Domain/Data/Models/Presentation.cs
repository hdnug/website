using System;
using System.Collections.Generic;

namespace Hdnug.Domain.Data.Models
{
    public class Presentation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PresentationDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }
        public int? MeetingId { get; set; }

        public Meeting Meeting { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }
}