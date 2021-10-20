using BookFlights.Business.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BookFlights.ConsumirAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese por favor el Origen en código IATA:");
            string Origin = Console.ReadLine();
            Console.WriteLine("Ingrese por favor el Destino en código IATA:");
            string Destination = Console.ReadLine();
            Console.WriteLine("Ingrese la fecha de vuelo en formato yyyy-MM-dd (año-mes-día):");
            string From = Console.ReadLine();
            Console.WriteLine("----------------------------------------------------------------");

            HttpClient httpClient = new HttpClient();
            var url = "https://testapi.vivaair.com/otatest/api/values";
            var data = new FlightAPI_DTO() { Origin = Origin, Destination = Destination, From = From };
            var dataSerializer = System.Text.Json.JsonSerializer.Serialize(data);
            var content = new StringContent(dataSerializer, Encoding.UTF8, "application/json");
            var request = httpClient.PostAsync(url, content).Result;


            if (request.IsSuccessStatusCode)
            {
               var  result = request.Content.ReadAsStringAsync().Result;
                result = result.TrimStart('\"');
                result = result.TrimEnd('\"');
                result = result.Replace("\\", "");
                List<FlightDTO> ListFlights = JsonConvert.DeserializeObject<List<FlightDTO>>(result);

                foreach(var item in ListFlights)
                {
                    Console.WriteLine("DepartureDate: " + item.DepartureDate);
                    Console.WriteLine("DepartureStation: " + item.DepartureStation);
                    Console.WriteLine("ArrivalStation: " + item.ArrivalStation);
                    Console.WriteLine("FlightNumber: " + item.FlightNumber);
                    Console.WriteLine("Price: " + item.Price);
                    Console.WriteLine("Currency: " + item.Currency);
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine(request.StatusCode);
            }

        }
    }
}
