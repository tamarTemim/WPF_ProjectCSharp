using DAL_INTERFACE;
using Entities;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace UI_WPF
{
    public static class Cache
    {
        public static Entities.Volunteer? CurrentVolunteer { get; set; }
        /// <summary>
        /// Creates and returns an instance of <see cref="ICallDal"/> based on the type name specified in the
        /// application configuration.
        /// </summary>
        /// <remarks>The type name must be specified in the application's configuration file under the
        /// <c>dal</c> key in the <c>appSettings</c> section. The specified type must implement <see cref="ICallDal"/>
        /// and be accessible at runtime.</remarks>
        /// <returns>An instance of <see cref="ICallDal"/> created from the type specified in the configuration.</returns>
        /// <exception cref="Exception">Thrown if the <c>dal</c> key is missing from the configuration, or if the specified type cannot be found or
        /// instantiated.</exception>
        public static ICall GetCallDalByConfig()
        {
            //קריאה מהקובץ הקונפיגורציה כדי לקבל את שם המחלקה הרצויה
            //שם המחלקה כולל גם את  שם מרחב-השמות ==namespace+class 
            string dalName = ConfigurationManager.AppSettings["CallDal"] ?? throw new Exception("dal not found in config file");
            String assemblyName = ConfigurationManager.AppSettings["AssemblyName"] ?? throw new Exception("dal not found in config file");

            dalName += $", {assemblyName}";

            //"Namespace.ClassName, AssemblyName"
            Type type = Type.GetType(dalName) ?? throw new Exception("לא נמצא טיפוס נתונים מתאים"); ;


            //יוצרת אוביקט לפי משתנה טיפוס שקיבלנו
            ICall dalOb = (ICall)Activator.CreateInstance(type);

            return dalOb;
        }

        internal static IVolunteer GetVolunteerDalByConfig()
        {
            //קריאה מהקובץ הקונפיגורציה כדי לקבל את שם המחלקה הרצויה
            //שם המחלקה כולל גם את  שם מרחב-השמות ==namespace+class 
            string dalName = ConfigurationManager.AppSettings["VolunteerDal"] ?? throw new Exception("dal not found in config file");
            String assemblyName = ConfigurationManager.AppSettings["DalAssemblyName"] ?? throw new Exception("dal not found in config file");

            dalName += $", {assemblyName}";

            string assemblyFullPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"{assemblyName}.dll");
            //"Namespace.ClassName, AssemblyName"

            Assembly a = Assembly.LoadFrom(assemblyFullPath);

            Type type = Type.GetType(dalName) ?? throw new Exception("לא נמצא טיפוס נתונים מתאים"); ;

            //יוצרת אוביקט לפי משתנה טיפוס שקיבלנו
            IVolunteer dalOb = (DAL_INTERFACE.IVolunteer)Activator.CreateInstance(type);

            return dalOb;
        }




        //public Cache()
        //{
        //    using (SqlConnection conn = new SqlConnection(new Common().ConnectionString))
        //    {
        //        conn.Open();

        //        // Query: traer el primer volunteer
        //        string sql = @"SELECT TOP 1 
        //                    Id,
        //                    TZ, 
        //                    FullName, 
        //                    Number, 
        //                    Email, 
        //                    Password, 
        //                    Address, 
        //                    Job, 
        //                    MaxDistance, 
        //                    DistanceType
        //               FROM Volunteer"; // Ajusta los campos si tu tabla tiene más

        //        using (SqlCommand cmd = new SqlCommand(sql, conn))
        //        {
        //            using (SqlDataReader reader = cmd.ExecuteReader())
        //            {
        //                if (reader.Read())
        //                {
        //                    CurrentVolunteer = new Volunteer
        //                    {
        //                        Id = reader.GetInt32(reader.GetOrdinal("Id")),
        //                        TZ = reader.GetInt32(reader.GetOrdinal("TZ")),
        //                        FullName = reader.GetString(reader.GetOrdinal("FullName")),
        //                        Number = reader.GetInt32(reader.GetOrdinal("Number")),
        //                        Email = reader.GetString(reader.GetOrdinal("Email")),
        //                        Password = reader.GetString(reader.GetOrdinal("Password")),
        //                        Address = reader.GetString(reader.GetOrdinal("Address")),
        //                        Job = reader.GetString(reader.GetOrdinal("Job")), // si Job es string, sino castealo
        //                        MaxDistance = reader.GetDouble(reader.GetOrdinal("MaxDistance")),
        //                        DistanceType = (DistanceType)reader.GetInt32(reader.GetOrdinal("DistanceType"))
        //                    };
        //                }
        //            }

        //        }

        //    }
        //}

    }
}
