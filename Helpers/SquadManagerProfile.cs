using AutoMapper;
using Squad_Manager.Model.Dtos.PersonDtos;
using Squad_Manager.Model.Dtos.UserDtos;
using Squad_Manager.Model.Entity;

namespace Squad_Manager.Helpers
{
    public class SquadManagerProfile : Profile
    {
        public SquadManagerProfile()
        {
            CreateMap<User, UserDto>(); //get

            CreateMap<Person, PersonDto>();

            CreateMap<Squad, SquadDto>();

            CreateMap<UserCreateDto, User>(); //create

            CreateMap<UserUpdateDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //edit

            CreateMap<UserLoginDto, User>();
        }
    }
}
