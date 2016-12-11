using System.Collections.Generic;
using Hdnug.Domain.Data.Models;

namespace Hdnug.Web.Models.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {
            Meetings = new List<Meeting>();
            Sponsors = new List<Sponsor>();
            PrizeSponsors = new List<PrizeSponsorship>();
            SliderImages = new List<Image>();
        }
        public int PresentationCount { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; }
        public IEnumerable<Sponsor> Sponsors { get; set; }
        public IEnumerable<PrizeSponsorship> PrizeSponsors { get; set; }
        public IEnumerable<Image> SliderImages { get; set; }
    }
}