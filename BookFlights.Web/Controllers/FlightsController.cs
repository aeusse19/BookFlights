using BookFlights.Business.DTOs;
using BookFlights.Web.Cors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BookFlights.Web.Controllers
{
    public class FlightsController : Controller
    {
        public ActionResult Index()
        {
            FlightAPI_DTO data = new FlightAPI_DTO();
            data.Origin = "BOG";
            data.Destination = "CTG";
            data.From = "2021-10-20";

            //data.From = DateTime.Now.ToString();

            var url = $"http://testapi.vivaair.com/otatest/api/values";
            var request = (HttpWebRequest)WebRequest.Create(url);
            string json = $"{{\"data\":\"{data}\"}}";
            request.Method = "POST";
            request.ContentType = "application/json";
            request.Accept = "application/json";
            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                using (WebResponse response = request.GetResponse())
                {
                    using (Stream strReader = response.GetResponseStream())
                    {
                        if (strReader == null)
                            return View();
                        using (StreamReader objReader = new StreamReader(strReader))
                        {
                            string responseBody = objReader.ReadToEnd();
                            // Do something with responseBody
                            Console.WriteLine(responseBody);
                        }
                    }
                }
            }
            catch (WebException ex)
            {
                // Handle error
            }

            return View();
        }
    }
}