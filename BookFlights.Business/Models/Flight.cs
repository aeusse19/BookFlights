using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookFlights.Business.Models
{
    [Table("Flight", Schema = "dbo")]
    public class Flight
    {
        public string DepatureStation { get; set; }
        public string ArrivalStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public Transport transport  { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

        public Flight(Transport transport)
        {
            if (transport == null)
                throw new Exception("No se puede crear un vuelo sin un número de vuelo asociado");
            Transport = Transport;
        }

        public Transport Transport
        {
            get 
            { 
                return transport;
            }
            set
            {
                transport = value;
            }
        }
    }
}
