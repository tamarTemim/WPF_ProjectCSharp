using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public enum Job
    {
        Aerial,
        Volunteer,
        Director 
    }
    public enum DistanceType
    {
        Walk, 
        Car, 
        
    }
    public class Volunteer
    {
        public int Id { get; set; }
        public int TZ { get; set; }
        public string FullName { get; set; }
        public int Number { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Job { get; set; }
        public double MaxDistance { get; set; }
        public DistanceType DistanceType { get; set; }
        public List<Call> ListCalls { get; set; }
        public Volunteer()
        {
            Id = Configuration.NextVolunteerId++;
            
        }

        

    }
}
