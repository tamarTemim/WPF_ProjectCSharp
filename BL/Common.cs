
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;


namespace BL
{
    internal class Common
    {
        public static bool TryGetCoordinates(string address, string apiKey, out double latitude, out double longitude)
        {
            latitude = 0;
            longitude = 0;

            try
            {
                string url = "https://maps.googleapis.com/maps/api/geocode/json?address="
                              + Uri.EscapeDataString(address)
                              + "&key=" + apiKey;

                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string json = reader.ReadToEnd();

                    JObject root = JObject.Parse(json);

                    string status = (string)root["status"];
                    if (status != "OK")
                        return false;

                    var location = root["results"][0]["geometry"]["location"];
                    latitude = (double)location["lat"];
                    longitude = (double)location["lng"];

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
