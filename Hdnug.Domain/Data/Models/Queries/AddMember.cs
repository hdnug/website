using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class AddMember : Command
    {
        public AddMember(string email)
        {
            ContextQuery = context =>
            {
                var m = new Member
                {
                    Email = email
                };
                context.Add(m);
                context.Commit();
            };
        }

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
