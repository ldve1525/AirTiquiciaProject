using AirTiquicia.Core.DTOs;
using AirTiquicia.Core.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AirTiquicia.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Airplane, AirplaneDTO>();
            CreateMap<AirplaneDTO, Airplane>();

            CreateMap<Airport, AirportDTO>();
            CreateMap<AirportDTO, Airport>();

            CreateMap<Price, PriceDTO>();
            CreateMap<PriceDTO, Price>();

            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
