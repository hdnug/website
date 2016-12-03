using Hdnug.Domain.Data.Models;
using System.Collections.Generic;

namespace Hdnug.Web.Areas.Admin.Models.ViewModels
{
    public class MeetingListViewModel
    {
        public MeetingListViewModel()
        {
            Meetings = new List<Meeting>();
        }
        public IEnumerable<Meeting> Meetings { get; set; }
    }
}