using System.Collections.Generic;
using Highway.Data;

namespace Hdnug.Domain.Data.Models
{
    public class Sponsor : IIdentifiable<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TagLine { get; set; }
        public string SponsorMessage { get; set; }
        public string WebSiteUrl { get; set; }


        public virtual Image Logo { get; set; }
        public virtual ICollection<Meeting> Meetings  { get; set; }
    }
}