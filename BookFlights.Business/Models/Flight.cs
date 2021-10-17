using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookFlights.Business.Models
{
    [Table("Flight", Schema = "dbo")]
    public class Flight
    {
        [Key]
        public int Id { get; set; }
        public string DepartureStation { get; set; }
        public string ArrivalStation { get; set; }
        public DateTime DepartureDate { get; set; }
        public string FlightNumber { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }

    }
}
