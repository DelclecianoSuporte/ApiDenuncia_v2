using ApiDenuncia.Models;

namespace ApiDenuncia.ViewModel
{
    public class ImagemViewModel
    {
        public Guid Id { get; set; }
        public byte[] Conteudo { get; set; }
        public string NomeArquivo { get; set; }
        public string Tipo { get; set; }
        public Denuncia Denuncia { get; set; }
    }
}
