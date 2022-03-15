using AutoMapper;
using Squad_Manager.Model.Dtos.PersonDtos;
using Squad_Manager.Model.Dtos.SquadDtos;
using Squad_Manager.Model.Dtos.TaskDtos;
using Squad_Manager.Model.Dtos.UserDtos;
using Squad_Manager.Model.Entity;
using Task = Squad_Manager.Model.Entity.Task;

namespace Squad_Manager.Helpers
{
    public class SquadManagerProfile : Profile
    {
        public SquadManagerProfile()
        {
            // User
            CreateMap<User, UserDto>(); //get
            CreateMap<User, UserDetailsDto>();
            CreateMap<UserCreateDto, User>(); //create
            CreateMap<UserUpdateDto, User>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //edit
            CreateMap<UserLoginDto, User>();

            // Person
            CreateMap<Person, PersonDto>();
            CreateMap<Person, PersonDetailsDto>();
            CreateMap<Person, PersonSquadUser>();
            CreateMap<PersonCreateDto, Person>();
            CreateMap<PersonUpdateDto, Person>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //edit

            //Squad
            CreateMap<Squad, SquadDto>();
            CreateMap<Squad, SquadDetailsDto>();
            CreateMap<SquadCreateDto, Squad>();
            CreateMap<SquadUpdateDto, Squad>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //edit

            //Task

            CreateMap<Task, TaskDto>();
            CreateMap<TaskCreateDto, Task>();
            CreateMap<TaskUpdateDto, Task>().ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null)); //edit
        }
    }
}
