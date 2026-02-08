using Entities;
using System;
using WareHouse;

namespace DAL
{
    public class DAL_Solution
    {
        public bool AddVolunteerDAL( int TZ, string FullName, int Number, string Email, string Password, string Address, string Job, double MaxDistance, DistanceType DistanceType)
        {
            
            if (DataBase.DicVolunteers.ContainsKey(TZ))
            {
                throw new DataException(TZ, "The user already exists");
            }
            Volunteer v = new Volunteer() { TZ = TZ, FullName = FullName, Number = Number, Email = Email, Password = Password, Address = Address, Job = Job, MaxDistance = MaxDistance, DistanceType = DistanceType };
            DataBase.DicVolunteers.Add(TZ, v);
            return true;
        }
        public bool AddCallDAL(Category category , string Description, string AddressCall ,DateTime DateNeed)
        {
            Call c = new Call() { Category = category, Description = Description, AddressCall = AddressCall, DateNeed = DateNeed };
            if (DataBase.DicCalls.ContainsKey(c.Id))
                throw new DataException(c.Id, "The call already exists");
            DataBase.DicCalls.Add(c.Id, new Call() { Id = c.Id, Category = category, Description = Description, AddressCall = AddressCall, DateNeed = DateNeed });
            return true;
        }
         

     
    }
}
