using Hdnug.Domain.Data.Models;
using System.Collections.Generic;

namespace Hdnug.Web.Models.ViewModels
{
    public class MeetingDetailsViewModel
    {
        public Meeting Meeting { get; set; }

        public Presentation Presentation { get; set; }

        public IEnumerable<Sponsor> Sponsors { get; set; }

        public IEnumerable<PrizeSponsorship> PrizeSponsors { get; set; }
    }
}