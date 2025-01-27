using System.ComponentModel.DataAnnotations;

namespace ApiDenuncia.Models
{
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "o nome do usuario é obrigatório")]
        [MaxLength(250, ErrorMessage = "O tamanho do nome não pode exceder 250 caracteres")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "o email do usuario é obrigatório")]
        [MaxLength(200, ErrorMessage = "O tamanho do email não pode exceder 200 caracteres")]
        public string Email { get; private set; }

        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt)
        {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
