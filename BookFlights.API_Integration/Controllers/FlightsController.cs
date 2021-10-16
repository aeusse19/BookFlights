using AutoMapper;
using BookFlights.Business.Data;
using BookFlights.Business.DTOs;
using BookFlights.Business.Repositories.Implementation;
using BookFlights.Business.Services.Implementation;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace BookFlights.API_Integration.Controllers
{
    public class FlightsController : ApiController
    {
        private IMapper mapper;
        private readonly FlightService flightService = new FlightService(new FlightRepository(BookFlightsContext.Create()));

        public FlightsController()
        {
            this.mapper = WebApiApplication.MapperConfiguration.CreateMapper();
        }

        [HttpGet]
        public async Task<IHttpActionResult> GetAll()
        {
            var flights = await flightService.GetAll();
            var flightDTO = flights.Select(x => mapper.Map<FlightDTO>(x));

            return Ok(flightDTO);
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetById(int Id)
        {
            var flight = await flightService.GetById(Id);

            if (flight == null)
            {
                return NotFound();
            }
            else
            {
                var flightDTO = mapper.Map<FlightDTO>(flight);
                return Ok(flightDTO);
            }                 
        }
    }
}
