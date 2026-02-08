using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dependency_Injection
{
    class DAL_DI : IDAL_Volunteer
    {
        public int GetNumber()
        {
            return Environment.CurrentManagedThreadId;
        }
    }
}
