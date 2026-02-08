using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Call
    {
        public int Id { get; set; } 
        public Category Category { get; set; }
        public string Description { get; set; }
        public string AddressCall { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DateAdded { get; set; }
        public DateTime DateNeed { get; set; }
        public int VolunteerId { get; set; }
        public Call() {
            Id = Configuration.NextCallId;
            Configuration.NextCallId++;
            DateAdded = Configuration.Clock;
            
        }
    }
}
