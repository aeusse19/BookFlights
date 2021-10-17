using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookFlights.Business.Models
{
    [Table("Transport", Schema = "dbo")]
    public class Transport
    {
        [Key]
        public int TransportID { get; set; }
        public string FlightNumber { get; set; }
    }
}
