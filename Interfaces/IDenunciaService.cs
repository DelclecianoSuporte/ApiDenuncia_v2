using ApiDenuncia.Models;

namespace ApiDenuncia.Interfaces
{
    public interface IDenunciaService
    {
        Task Adicionar(Denuncia denuncia);
        Task<IEnumerable<Denuncia>> ObterTodosProtocolos();
    }
}
