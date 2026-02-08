using Entities;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;

namespace WareHouse
{

    public class DataBase
    {
      
        //   CATEGORIES
        public static  Dictionary<int, Category> DicCategories = new Dictionary<int, Category>()
        {
            {1, new Category { Id = 1, CallType ="Food"}},
            {2, new Category { Id = 2, CallType = "Babbysitting "}},
            {3, new Category { Id = 3, CallType = "Medical Help" }},
            {4, new Category { Id = 4, CallType = "House Cleanning" }}
        };
        //   VOLUNTEERS
        public  static Dictionary<int, Volunteer> DicVolunteers = new Dictionary<int, Volunteer>()
        {
            {
                1,
                new Volunteer
                {
                    TZ = 123456789,
                    FullName = "Juan Pérez",
                    Number = 111111111,
                    Email = "juan@example.com",
                    Password = "1234",
                    Address = "Calle A 123",
                    Latitude = 32.066,
                    Longitude = 34.777,
                    Job = "Volunteer",
                    MaxDistance = 5.0,
                    DistanceType = DistanceType.Walk,
                    ListCalls = new List<Call>()
                }
            },

            {
                2,
                new Volunteer
                {
                    TZ = 987654321,
                    FullName = "María López",
                    Number = 222222222,
                    Email = "maria@example.com",
                    Password = "abcd",
                    Address = "Avenida B 456",
                    Latitude = 32.070,
                    Longitude = 34.780,
                    Job = "Aerial",
                    MaxDistance = 10.0,
                    DistanceType = DistanceType.Car,
                    ListCalls = new List<Call>()
                }
            }
        };
        //   CALLS
        public static Dictionary<int, Call> DicCalls = new Dictionary<int, Call>()
        {
            {
                1,
                new Call
                {
                    Category = DicCategories[1],
                    Description = "Necesitan comida preparada",
                    AddressCall = "Calle C 22",
                    Latitude = 32.067,
                    Longitude = 34.776,
                    DateNeed = DateTime.Now.AddHours(2)
                }
            },

            {
                2,
                new Call
                {
                    Category = DicCategories[2],
                    Description = "Necesitan babysitter por 2 horas",
                    AddressCall = "Calle D 10",
                    Latitude = 32.071,
                    Longitude = 34.781,
                    DateNeed = DateTime.Now.AddHours(3)
                }
            }
        };
        
        //   GENERAR VOLUNTEERS
        static  void AddVolunteers(int cantidad = 30)
        {
            Random rnd = new Random();
            for (int i = 0; i < cantidad; i++)
            {
                var v = new Volunteer
                {
                    TZ = rnd.Next(100000000, 999999999),
                    FullName = $"Voluntario {DicVolunteers.Count + 1}",
                    Number = rnd.Next(100000000, 999999999),
                    Email = $"voluntario{DicVolunteers.Count + 1}@example.com",
                    Password = "1234",
                    Address = $"Calle {rnd.Next(1, 100)}",
                    Latitude = 32.0 + rnd.NextDouble(),
                    Longitude = 34.0 + rnd.NextDouble(),
                    Job = "Volunteer",
                    MaxDistance = rnd.Next(1, 20),
                    DistanceType = (DistanceType)rnd.Next(0, 2),
                    ListCalls = new List<Call>()
                };

                DicVolunteers[v.Id] = v;
            }
        }

        //   GENERAR CALLS
        static  void AddCalls()
        {
            Random rnd = new Random();
            var categoryKeys = new List<int>(DicCategories.Keys);
            for (int i = 0; i < 30; i++)
            {
                int catKey = categoryKeys[rnd.Next(categoryKeys.Count)];

                var c = new Call
                {
                    Category = DicCategories[catKey],
                    Description = $"Descripción de llamada {DicCalls.Count + 1}",
                    AddressCall = $"Calle {rnd.Next(1, 200)}",
                    Latitude = 32.0 + rnd.NextDouble(),
                    Longitude = 34.0 + rnd.NextDouble(),
                    DateNeed = DateTime.Now.AddHours(rnd.Next(1, 72))
                };

                DicCalls[c.Id] = c;
            }
        }
         static DataBase()
        {
            AddCalls();
            AddVolunteers();

        }
    }
}
