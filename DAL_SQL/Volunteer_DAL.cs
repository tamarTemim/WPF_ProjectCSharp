using Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using DAL_INTERFACE;
namespace DAL_SQL

{
    public class Volunteer_DAL : IVolunteer
    {

        public Volunteer Authenticate(string fullname, string password)
        {
            using SqlConnection conn = new SqlConnection();
            conn.ConnectionString = new Common().ConnectionString;
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Volunteer WHERE FullName=@fullname AND Password=@Password", conn);

            cmd.Parameters.AddWithValue("FullName", fullname);
            cmd.Parameters.AddWithValue("@Password", password);

            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();

            if (!reader.Read()) return null;

            Volunteer vol = new Volunteer();
            {
                vol.TZ = (int)reader["ID"];
                vol.FullName = (string)reader["FullName"];
                vol.Password = (string)reader["Password"];
                vol.Id = (int)reader["Id"];
                vol.Address = (string)reader["Address"];
                vol.Email = (string)reader["Email"];
                vol.Number = (int)reader["Number"];
                vol.Job = (string)reader["Job"];
                vol.DistanceType = (DistanceType)reader["DistanceType"];
                vol.MaxDistance = (double)(double?)reader["MaxDistance"];
                vol.Latitude = (double)(double?)reader["Latitude"];
                vol.Longitude = (double)(double?)reader["Longitude"];
            }
            ;

            return vol;
        }
        public bool DeleteVolunteer(int TZ)
        {
            using SqlConnection conn = new SqlConnection();
            conn.ConnectionString = new Common().ConnectionString;
            using SqlCommand cmd = new SqlCommand(
                "DELETE FROM Volunteer WHERE TZ=@TZ", conn);
            cmd.Parameters.AddWithValue("@TZ", TZ);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }

        public Volunteer GetVolunteer(int TZ)
        {
            using SqlConnection conn = new SqlConnection();
            conn.ConnectionString = new Common().ConnectionString;
            using SqlCommand cmd = new SqlCommand(
                "SELECT * FROM Volunteer WHERE TZ=@TZ", conn);
            cmd.Parameters.AddWithValue("@TZ", TZ);
            conn.Open();
            using SqlDataReader reader = cmd.ExecuteReader();
            Volunteer vol = null;
            if (!reader.Read())
                return vol;
            vol = new Volunteer();
            {
                {
                    vol.TZ = (int)reader["ID"];
                    vol.FullName = (string)reader["FullName"];
                    vol.Password = (string)reader["Password"];
                    vol.Id = (int)reader["Id"];
                    vol.Address = (string)reader["Address"];
                    vol.Email = (string)reader["Email"];
                    vol.Number = (int)reader["Number"];
                    vol.Job = (string)reader["Job"];
                    vol.DistanceType = (DistanceType)reader["DistanceType"];
                    vol.MaxDistance = (double)(double?)reader["MaxDistance"];
                    vol.Latitude = (double)(double?)reader["Latitude"];
                    vol.Longitude = (double)(double?)reader["Longitude"];
                }
                ;

                return vol;
            }

        }

        public bool AddVolunteer(Volunteer vol)
        {
            using SqlConnection conn = new SqlConnection();
            conn.ConnectionString = new Common().ConnectionString;
            using SqlCommand cmd = new SqlCommand(
                "INSERT INTO Volunteer (TZ, FullName, Number, Email, Password, Address, Job, MaxDistance, DistanceType, Latitude, Longitude) " +
                "VALUES (@TZ, @FullName, @Number, @Email, @Password, @Address, @Job, @MaxDistance, @DistanceType, @Latitude, @Longitude)", conn);
            cmd.Parameters.AddWithValue("@TZ", vol.TZ);
            cmd.Parameters.AddWithValue("@FullName", vol.FullName);
            cmd.Parameters.AddWithValue("@Number", vol.Number);
            cmd.Parameters.AddWithValue("@Email", vol.Email);
            cmd.Parameters.AddWithValue("@Password", vol.Password);
            cmd.Parameters.AddWithValue("@Address", vol.Address);
            cmd.Parameters.AddWithValue("@Job", vol.Job);
            cmd.Parameters.AddWithValue("@MaxDistance", vol.MaxDistance);
            cmd.Parameters.AddWithValue("@DistanceType", vol.DistanceType);
            cmd.Parameters.AddWithValue("@Latitude", vol.Latitude);
            cmd.Parameters.AddWithValue("@Longitude", vol.Longitude);
            conn.Open();
            int rows = cmd.ExecuteNonQuery();
            return rows > 0;
        }



    }
}
