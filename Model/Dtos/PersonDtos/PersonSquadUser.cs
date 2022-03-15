using Squad_Manager.Model.Dtos.SquadDtos;
using Squad_Manager.Model.Dtos.UserDtos;

namespace Squad_Manager.Model.Dtos.PersonDtos
{
    public class PersonSquadUser
    {
        public int Id { get; set; }
        public UserDetailsDto User { get; set; }
        public SquadDetailsDto Squad { get; set; }
    }
}
