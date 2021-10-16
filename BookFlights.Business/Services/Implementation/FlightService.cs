using BookFlights.Business.Models;
using BookFlights.Business.Repositories.Contracts;
using BookFlights.Business.Services.Contracts;

namespace BookFlights.Business.Services.Implementation
{
    public class FlightService : BusinessService<Flight>,IFlightService
    {
        public FlightService(IFlightRepository flightRepository) : base (flightRepository)
        {
             
        }
    }
}
