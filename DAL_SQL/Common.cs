using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;

namespace DAL_SQL
{
    public class Common
    {
        public string ConnectionString { get;}
        public Common()
        {
            string configName = "default";
            if(Environment.UserName == "st242")
                configName = "DbOfakim";
           
            ConnectionString = ConfigurationManager.ConnectionStrings[configName].ConnectionString;
        }
        
    }
}
