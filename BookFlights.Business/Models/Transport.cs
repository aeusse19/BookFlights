using System.ComponentModel.DataAnnotations.Schema;

namespace BookFlights.Business.Models
{
    [Table("Transport", Schema = "dbo")]
    public class Transport
    {
        public string FlightNumber { get; set; }
    }
}
