using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hdnug.Domain.Data.Models.Mapping
{
    public class LocationMap: EntityTypeConfiguration<Location>
    {
        public LocationMap()
        {
            ToTable("Location");
            HasKey(t => t.Id);
           
            Ignore(e => e.LocationAddress); 
        }
    }
}
