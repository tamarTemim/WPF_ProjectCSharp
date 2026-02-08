using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL_INTERFACE;


namespace DAL_SQL
{
    public class Calls_DAL : ICall
    {

        public List<Call> GetAllCalls(bool OnlyOpendCalls)
        {
            List<Call> calls = new List<Call>();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = new Common().ConnectionString;
            string sqlCmdText =
            @"SELECT c.Id, c.Description, c.AddressCall, c.CategoryId, c.CategoryName AS CategoryName, c.DateNeed
              FROM Call c
              ";
            if (OnlyOpendCalls)
            {
                sqlCmdText += " WHERE c.VolunteerId IS NULL";
            }
            using SqlCommand cmd = new SqlCommand(sqlCmdText, conn);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                var category = new Category
                {
                    Id = (int)reader["CategoryId"],
                    CallType = (string)reader["CategoryName"]
                };

                var call = new Call();
                {
                    call.Id = (int)reader["Id"];
                    call.Description = (string)reader["Description"];
                    call.AddressCall = (string)reader["AddressCall"];
                    call.Category = category;
                    call.DateNeed = (DateTime)reader["DateNeed"];
                }
                calls.Add(call);
            }
            return calls;

        }
        public bool addVolunteerIdToCall_DAL(Call call, int volunteerId)
        {
           
            string query = "UPDATE Call SET VolunteerId = @VolunteerId WHERE Id = @CallId";

            using (SqlConnection conn = new SqlConnection())
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                conn.ConnectionString = new Common().ConnectionString;


                cmd.Parameters.AddWithValue("@VolunteerId", volunteerId);
                cmd.Parameters.AddWithValue("@CallId", call.Id);

                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery(); // Ejecuta la consulta
                conn.Close();

                return rowsAffected > 0;
            }
        }
        public bool AddVolunteerDAL(int TZ, string FullName, int Number, string Email, string Password,
                            string Address, string Job, double MaxDistance, DistanceType DistanceType)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = new Common().ConnectionString;

            string sqlCmdText =
            @"INSERT INTO Volunteer
      (TZ, FullName, Number, Email, Password, Address, Job, MaxDistance, DistanceType)
      VALUES
      (@TZ, @FullName, @Number, @Email, @Password, @Address, @Job, @MaxDistance, @DistanceType)";

            using SqlCommand cmd = new SqlCommand(sqlCmdText, conn);

            cmd.Parameters.AddWithValue("@TZ", TZ);
            cmd.Parameters.AddWithValue("@FullName", FullName);
            cmd.Parameters.AddWithValue("@Number", Number);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Job", Job);
            cmd.Parameters.AddWithValue("@MaxDistance", MaxDistance);
            cmd.Parameters.AddWithValue("@DistanceType", (int)DistanceType);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }
        public bool AddCallDAL(Category category, string Description, string AddressCall, DateTime DateNeed)
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = new Common().ConnectionString;

            string sqlCmdText =
            @"INSERT INTO Call
      (CategoryId, Description, AddressCall, DateNeed)
      VALUES
      (@CategoryId, @Description, @AddressCall, @DateNeed)";

            using SqlCommand cmd = new SqlCommand(sqlCmdText, conn);

            cmd.Parameters.AddWithValue("@CategoryId", category.Id);
            cmd.Parameters.AddWithValue("@Description", Description);
            cmd.Parameters.AddWithValue("@AddressCall", AddressCall);
            cmd.Parameters.AddWithValue("@DateNeed", DateNeed);

            conn.Open();
            int rowsAffected = cmd.ExecuteNonQuery();

            return rowsAffected > 0;
        }

      
    }
}
       
    
