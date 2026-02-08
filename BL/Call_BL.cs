
using DAL_INTERFACE;
using Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Call_BL

    {
        public ICall Icall_bl;
        public Call_BL(ICall Idal_Call )
        {
            Icall_bl = Idal_Call;   
        }
        public bool AddCallBL( Category category, string Description, string AddressCall, DateTime DateNeed)
        {
            
            return Icall_bl.AddCallDAL( category, Description, AddressCall, DateNeed);
        }
        public List<Call> GetAllCallsBL(bool OnlyOpenedCalls = false)
        {
           
            return Icall_bl.GetAllCalls(OnlyOpenedCalls);
        }
        public bool addVolunteerIdCall_BL(Call call, int VolunteerId)
        {
            
            return Icall_bl.addVolunteerIdToCall_DAL( call, VolunteerId );
        }
    }
}
