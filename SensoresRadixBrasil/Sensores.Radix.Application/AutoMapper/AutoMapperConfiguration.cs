using AutoMapper;

namespace Sensores.Radix.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddProfile(new DomainToDtoMappingProfile());
                mc.AddProfile(new DtoToDomainMappingProfile());

            });
        }
    }
}
