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
        public string DepatureStation { get; set; }
        public string ArrivalStation { get; set; }

        //[Required(ErrorMessage = "El campo es requerido")]
        public DateTime DepartureDate { get; set; }
        public Transport transport { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public string FlightNumber
        {
            get { return string.Format("{0}", transport.FlightNumber); }
        }
    }
}
