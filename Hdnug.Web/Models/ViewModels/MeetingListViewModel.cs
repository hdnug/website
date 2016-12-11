using Hdnug.Domain.Data.Models;
using System.Collections.Generic;

namespace Hdnug.Web.Models.ViewModels
{
    public class MeetingListViewModel
    {
        public int PresentationCount { get; set; }
        public IEnumerable<Meeting> Meetings { get; set; } = new List<Meeting>();
    }
}