using AutoMapper;
using BookFlights.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookFlights.Business.DTOs
{
    public class MapperConfig
    {
        public static MapperConfiguration MapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Flight, FlightDTO>(); //GET
                cfg.CreateMap<FlightDTO, Flight>(); //POST - PUT
            });
        }
    }
}
