using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public static class Configuration
    {
        public static int NextCallId = 0;
        public static int NextVolunteerId = 0;
        public static DateTime Clock = DateTime.Now;

    }
}
