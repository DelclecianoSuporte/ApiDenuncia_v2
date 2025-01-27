using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDenuncia.DTO
{
    public class UsuarioDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome do usuario é obrigatório")]
        [MaxLength(250, ErrorMessage = "O tamanho do nome não pode exceder 250 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O email do usuario é obrigatório")]
        [MaxLength(200, ErrorMessage = "O tamanho do email não pode exceder 200 caracteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatório")]
        [MaxLength(100, ErrorMessage = "A senha deve ter no máximo 100 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        [NotMapped]
        public string Password { get; set; }
    }
}
