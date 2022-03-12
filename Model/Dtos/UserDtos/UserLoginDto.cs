using System.ComponentModel.DataAnnotations;

namespace Squad_Manager.Model.Dtos.UserDtos
{
    public class UserLoginDto
    {

        [Required(ErrorMessage = "Informe o seu email")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Informe um email válido...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe sua senha")]
        public string Password { get; set; }
    }
}
