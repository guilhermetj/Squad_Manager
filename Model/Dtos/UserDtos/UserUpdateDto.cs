using System.ComponentModel.DataAnnotations;

namespace Squad_Manager.Model.Dtos.UserDtos
{
    public class UserUpdateDto
    {
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string? Email { get; set; }

        public string? Password { get; set; }

    }
}
