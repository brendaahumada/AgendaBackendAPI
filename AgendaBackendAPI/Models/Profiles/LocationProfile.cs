using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;

namespace AgendaBack2023.Models.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            // Mapeo de Location a LocationDto
            CreateMap<Location, LocationDto>();

            // Mapeo de CreateAndUpdateLocationDTO a Location
            CreateMap<CreateAndUpdateLocationDTO, Location>();

            // Mapeo de LocationDto a Location (agregado)
            CreateMap<LocationDto, Location>();
        }
    }
}
