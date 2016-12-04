using System;
using System.Collections.Generic;

namespace Hdnug.Domain.Data.Models
{
    public class Presentation
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PresentationStartDateTime { get; set; }
        public DateTime PresentationEndDateTime { get; set; }
        public string Location { get; set; }
        public string Url { get; set; }

        public ICollection<Meeting> Meetings { get; set; }
        public ICollection<Speaker> Speakers { get; set; }
    }
}