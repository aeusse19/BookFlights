using BookFlights.Business.Data;
using BookFlights.Business.Models;
using BookFlights.Business.Repositories.Contracts;

namespace BookFlights.Business.Repositories.Implementation
{
    public class FlightRepository : BusinessRepository<Flight>, IFlightRepository
    {
        public FlightRepository(BookFlightsContext bookFlightsContext) : base (bookFlightsContext)
        {

        }
    }
}
