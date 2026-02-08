using Entities;

namespace DAL_INTERFACE
{
    public interface ICall
    {
        public List<Call> GetAllCalls(bool onlyOpenCalls);
        public bool addVolunteerIdToCall_DAL(Call call, int volunteerId);
        public bool AddVolunteerDAL(int TZ, string FullName, int Number, string Email, string Password,
                            string Address, string Job, double MaxDistance, DistanceType DistanceType);
        public bool AddCallDAL(Category category, string Description, string AddressCall, DateTime DateNeed);

    }
}
