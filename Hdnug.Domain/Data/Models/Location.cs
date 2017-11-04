using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hdnug.Domain.Data.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Address1 { get; set; }
    
        public string Address2 { get; set; }


        public string City { get; set; }

        public string State { get; set; }

        public string PostalCode { get; set; }

        public string MapUrl { get; set; }

        public string LocationAddress
        {
            get
            {
                return string.Join(",", Address1, City, State, PostalCode);
            }
        }

    }
}
