using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;

namespace AgendaBack2023.Models.Profiles
{
    public class ContactProfile : Profile
    {
        public ContactProfile()
        {
            CreateMap<Contact, ContactDTO>();

            CreateMap<CreateAndUpdateContactDTO, Contact>();

            CreateMap<LocationDto, Location>();

        }

    }

}
