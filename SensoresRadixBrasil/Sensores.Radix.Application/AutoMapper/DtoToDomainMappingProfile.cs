using AutoMapper;
using Sensores.Radix.Application.DTOs;
using Sensores.Radix.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Sensores.Radix.Application.AutoMapper
{
    public class DtoToDomainMappingProfile : Profile
    {
        public DtoToDomainMappingProfile()
        {
            CreateMap<SensorEventDto, SensorEvent>()
                 .ConstructUsing(s => new SensorEvent(
                     s.Id,
                     s.Timestamp,
                     s.Valor,
                     Regex.Match(s.Tag, @"\.([^.]+$)").Groups[0].Value,
                     Regex.Match(s.Tag, @"([^\.]+)\.").Groups[0].Value,
                     Regex.Match(s.Tag, @"\.([^\.]+)\.").Groups[0].Value));
        }
    }
}
