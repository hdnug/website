using System.Collections.Generic;

namespace Hdnug.Domain.Data.Models
{
    public class Speaker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Bio { get; set; }
        public string WebSiteUrl { get; set; }

        public virtual Image Photo { get; set; }
        public virtual ICollection<Presentation> Presentations { get; set; }
    }
}