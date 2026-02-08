using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;

namespace DAL
{
    internal class DataException : Exception
    {
        public object Entitie; 
        public DataException(object enti, string message) : base(message) {
        this.Entitie = enti;
        }
    }
}
