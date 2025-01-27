using ApiDenuncia.Models;

namespace ApiDenuncia.Interfaces
{
    public interface IDenunciaRepository : IRepository<Denuncia>
    {
        Task<List<Denuncia>> ObterMensagensPorProtocolo(long numeroProtocolo);
        Task<IEnumerable<Denuncia>> ObterProtocolosAbertos();
    }
}
