using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hdnug.Web.Inrastructure.Interfaces
{
    public interface IMailingListService
    {
        void AddMember(string listname, string firstname, string lastname, string company, string email);
    }
}
