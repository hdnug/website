using System;
using System.Collections.Generic;
using Hdnug.Domain.Data.Models;

namespace Hdnug.Web.Areas.Admin.Models.ViewModels
{
    public class PresentationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PresentationStartDateTime { get; set; } = DateTime.Today.AddHours(18).AddMinutes(30);
        public DateTime PresentationEndDateTime { get; set; } = DateTime.Today.AddHours(20).AddMinutes(30);
        public string Location { get; set; }
        public string Url { get; set; }
        public List<int> SelectedSpeakers { get; set; } = new List<int>();

        public ICollection<Speaker> Speakers { get; set; } = new List<Speaker>();
    }
}