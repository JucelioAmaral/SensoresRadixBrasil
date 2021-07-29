using AutoMapper;
using Sensores.Radix.Application.DTOs;
using Sensores.Radix.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sensores.Radix.Application.AutoMapper
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<SensorEvent, SensorEventDto>();
        }
    }
}
