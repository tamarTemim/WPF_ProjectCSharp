
using DAL_INTERFACE;

using Entities;

namespace BL
{
    public class Volunteer_BL
    {
        public IVolunteer Ivolunteer_bl;
        public Volunteer_BL(IVolunteer ivolunteer)
        {
            Ivolunteer_bl = ivolunteer;
        }
        public bool AddVolunteerBL(int TZ, string FullName, int Number, string Email, string Password, string Address, string Job, double MaxDistance, DistanceType DistanceType)
        {
         Volunteer v = new Volunteer() { TZ = TZ, FullName = FullName, Number = Number, Email = Email, Password = Password, Address = Address, Job = Job, MaxDistance = MaxDistance, DistanceType = DistanceType };
            return Ivolunteer_bl.AddVolunteer(v);
        }
        public Volunteer Authenticate(Volunteer v)
        {
            
            return Ivolunteer_bl.Authenticate(v.FullName, v.Password);
        }
    }
}
