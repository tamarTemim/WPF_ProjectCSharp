using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using WareHouse;

namespace Chesed_UI
{
    internal class UI
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the relevant option: 1: add call 2: add volunteer");
            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    try
                    {
                        createNewCall();
                    }
                    catch (Exception e) {
                        Console.WriteLine(e);
                    }
                    foreach (object arg in DataBase.DicCalls)
                    {
                        Console.WriteLine(arg.ToString());
                    }
                    break;
                case "2":
                    try
                    {
                        createNewVolunteer();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    foreach (object arg in DataBase.DicVolunteers)
                    {
                        Console.WriteLine(arg.ToString());
                    }
                    break;
            }

          

            void createNewVolunteer()
            {

                //new Volunteer
                Console.Write("Enter ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter TZ: ");
                int tz = int.Parse(Console.ReadLine());

                Console.Write("Enter complete name: ");
                string fullName = Console.ReadLine();

                Console.Write("Enter phone number: ");
                int number = int.Parse(Console.ReadLine());

                Console.Write("Enter email: ");
                string email = Console.ReadLine();

                Console.Write("Enter email: ");
                string password = Console.ReadLine();

                Console.Write("Enter address: ");
                string address = Console.ReadLine();

                Console.Write("Enter type of Job (0, 1, 2): ");
                string job = (Console.ReadLine());

                Console.Write("Enter maximum distance: ");
                double maxDistance = double.Parse(Console.ReadLine());

                Console.Write("Enter type of distance: (0 = Walk, 1 = Car): ");
                DistanceType distanceType = (DistanceType)int.Parse(Console.ReadLine());

                BL.Volunteer_BL chesed_BL_Volunteer = new BL.Volunteer_BL();
                if (chesed_BL_Volunteer.AddVolunteerBL(tz, fullName, number, email, password, address, job, maxDistance, distanceType))
                {
                    Console.WriteLine("The volunteer was added");
                }
                else
                { Console.WriteLine("Couldnt add the volunteer"); }
            }

            void createNewCall()
            {

                // New Call
                Console.Write("Enter Call ID: ");
                int idC = int.Parse(Console.ReadLine());

                Console.Write("Enter Category ID (must exist in Categories): ");
                int categoryId = int.Parse(Console.ReadLine());
                Category category = WareHouse.DataBase.DicCategories[categoryId];

                Console.Write("Enter Description: ");
                string description = Console.ReadLine();

                Console.Write("Enter Call Address: ");
                string addressCall = Console.ReadLine();

                Console.Write("Enter Date Needed (yyyy-MM-dd HH:mm): ");
                DateTime dateNeed = DateTime.Parse(Console.ReadLine());

                BL.Call_BL chesed_BL_Call = new BL.Call_BL();
                if (chesed_BL_Call.AddCallBL(idC, category, description, addressCall, dateNeed))
                {
                    Console.WriteLine("The call was added");
                }
                else
                { Console.WriteLine("Couldnt add the call"); }
            }
        }


    }
}
