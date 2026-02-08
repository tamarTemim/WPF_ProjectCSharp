using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    class BL_DI : IBL
    {
        readonly IDAL_Volunteer _dal;
        public BL_DI(IDAL_Volunteer dal)
        {
            _dal = dal;
        }
        public int GetNumberFromDAL()
        {
            return _dal.GetNumber();
        }
    }
}
