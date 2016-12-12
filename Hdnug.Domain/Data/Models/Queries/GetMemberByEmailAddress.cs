using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetMemberByEmailAddress : Scalar<Member>
    {
        public GetMemberByEmailAddress(string emailAddress)
        {
            ContextQuery = context => context.AsQueryable<Member>().Single(s => s.Email == emailAddress);
        }
    }
}