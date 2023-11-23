using AgendaBackendAPI.Entities;
using AgendaBackendAPI.Models.Dtos;
using AutoMapper;

namespace AgendaBack2023.Models.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, CreateAndUpdateUserDTO>();
            CreateMap<User, UserDto>();
            CreateMap<CreateAndUpdateUserDTO, User>();
            CreateMap<UserDto, User>();
        }
    }
}
