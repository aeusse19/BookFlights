using AutoMapper;
using BookFlights.Business.Data;
using BookFlights.Business.DTOs;
using BookFlights.Business.Models;
using BookFlights.Business.Repositories.Implementation;
using BookFlights.Business.Services.Implementation;
using System;
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
                 return NotFound();
            
            var flightDTO = mapper.Map<FlightDTO>(flight);
            return Ok(flightDTO);
        }

        [HttpPost]
        public async Task<IHttpActionResult> Post(FlightDTO flightDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                //Transport tran = new Transport();
                //tran.FlightNumber = flightDTO.FlightNumber;
                //flightDTO.transport = tran;
                var flight = mapper.Map<Flight>(flightDTO);
                flight = await flightService.Insert(flight);
                return Ok(flight);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex); 
            }           
        }

        [HttpPut]
        public async Task<IHttpActionResult> Put(FlightDTO flightDTO, int Id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //if (flightDTO.FlightID != Id)
            //    return BadRequest();

            var flag = await flightService.GetById(Id);

            if (flag == null)
                return NotFound();

            try
            {
                var flight = mapper.Map<Flight>(flightDTO);
                flight = await flightService.Update(flight);
                return Ok(flight);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpDelete]
        public async Task<IHttpActionResult> Delete(int Id)
        {
            var flight = await flightService.GetById(Id);

            if (flight == null)
                return NotFound();
            try
            {
                await flightService.Delete(Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
