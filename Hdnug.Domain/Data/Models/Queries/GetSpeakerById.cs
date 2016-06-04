using System;
using System.Data.Entity;
using System.Linq;
using Highway.Data;

namespace Hdnug.Domain.Data.Models.Queries
{
    public class GetSpeakerById : Scalar<Speaker>
    {
        public GetSpeakerById(int id)
        {
            ContextQuery = context => context.AsQueryable<Speaker>().Include(s => s.Photo).Single(s => s.Id == id);
        }
    }
}