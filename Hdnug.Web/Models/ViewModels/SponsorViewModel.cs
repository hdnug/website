using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Hdnug.Domain.Data.Models;

namespace Hdnug.Web.Models.ViewModels
{
    public class SponsorViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string TagLine { get; set; }
        public string SponsorMessage { get; set; }
        public string WebSiteUrl { get; set; }

        public string LogoUrl { get; set; }

        public HttpPostedFileBase Logo { get; set; }
    }
}