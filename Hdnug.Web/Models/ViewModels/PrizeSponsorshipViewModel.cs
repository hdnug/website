using System;
using System.Collections.Generic;
using Hdnug.Domain.Data.Models;

namespace Hdnug.Web.Models.ViewModels
{
    public class PrizeSponsorshipViewModel
    {
        public int Id { get; set; }
        public int SponsorId { get; set; }

        public string SponsorName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public IEnumerable<Sponsor> Sponsors { get; set; }
    }
}