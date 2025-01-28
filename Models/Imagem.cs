namespace ApiDenuncia.Models
{
    public class Imagem : Entity
    {
        public byte[] Conteudo { get; set; }
        public string NomeArquivo { get; set; }
        public string Tipo { get; set; }    
        public Denuncia Denuncia { get; set; }
    }
}
