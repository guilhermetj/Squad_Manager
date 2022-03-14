using Squad_Manager.Model.Dtos.PersonDtos;
using Squad_Manager.Model.Entity;
using System.ComponentModel.DataAnnotations;

namespace Squad_Manager.Model.Dtos.UserDtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<PersonDetailsDto> Person { get; set; }
    }
}
