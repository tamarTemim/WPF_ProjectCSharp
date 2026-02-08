using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_INTERFACE
{
    public interface IVolunteer
    {
        public Volunteer Authenticate(string fullname, string password);
        public bool DeleteVolunteer(int TZ);
        public Volunteer GetVolunteer(int TZ);
        public bool AddVolunteer(Volunteer vol);
    }
}
