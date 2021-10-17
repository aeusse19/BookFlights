using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookFlights.Business.Models;

namespace BookFlights.Business.DTOs
{
    public class FlightDTO
    {
        public int Id { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
