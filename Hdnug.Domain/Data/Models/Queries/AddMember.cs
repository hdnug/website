using Highway.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class AddMember : Command
    {
        public AddMember(string firstname, string lastname, string company, string email)
        {
            ContextQuery = context =>
            {
                var m = new Member
                {
                    FirstName = firstname,
                    LastName = lastname,
                    Company = company,
                    Email = email
                };

                context.Add(m);

                context.Commit();
            };
        }
    }
}
