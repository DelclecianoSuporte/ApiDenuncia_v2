using System.ComponentModel.DataAnnotations;

namespace ApiDenuncia.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "O e-mail é obrigatório")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }    
    }
}
