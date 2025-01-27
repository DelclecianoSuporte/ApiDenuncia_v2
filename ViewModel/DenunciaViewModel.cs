using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace ApiDenuncia.ViewModel
{
    public class DenunciaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public long Numero_Protocolo { get; set; }

        [ScaffoldColumn(false)]
        public DateTime Data_Protocolo { get; set; }
        public string Mensagem { get; set; }

        public string Status { get; set; } = "Aberto";

        public string Resposta { get; set; } = "";
    }
}
