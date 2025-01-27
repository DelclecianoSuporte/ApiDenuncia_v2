using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiDenuncia.Models
{
    public class Denuncia : Entity
    {
        public long Numero_Protocolo { get; set; }

        public DateTime Data_Protocolo { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Mensagem { get; set; }

        public string Status { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Resposta { get; set; }
        public DateTime? DataHora_Resposta { get; set; }
    }
}
