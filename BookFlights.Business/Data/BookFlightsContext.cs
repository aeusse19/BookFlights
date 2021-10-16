using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BookFlights.Business.Models;

namespace BookFlights.Business.Data
{
    public class BookFlightsContext : DbContext
    {
        private static BookFlightsContext bookFlightsContext = null;
        public BookFlightsContext() 
            : base("BookFlightsContext")
        {
            
        }

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Transport> Transports { get; set; }

        public static BookFlightsContext Create()
        {
            //if(bookFlightsContext == null)
            //    bookFlightsContext = new BookFlightsContext();

            //return bookFlightsContext;

            return new BookFlightsContext();
        }
    }
}
