using AutoMapper;
using Squad_Manager.Model.Dtos.UserDtos;
using Squad_Manager.Model.Entity;

namespace Squad_Manager.Helpers
{
    public class SquadManagerProfile : Profile
    {
        public SquadManagerProfile()
        {
            CreateMap<User, UserDto>(); //get

            CreateMap<UserCreateDto, User>(); //create

            CreateMap<UserUpdateDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //edit
        }
    }
}
