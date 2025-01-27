using ApiDenuncia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiDenuncia.Models
{
    public class DenunciaRepository : Repository<Denuncia>, IDenunciaRepository
    {
        public DenunciaRepository(Contexto db) : base(db){}

        public async Task<List<Denuncia>> ObterMensagensPorProtocolo(long numeroProtocolo)
        {
            var mensagens = await DbSet.Where(m => m.Numero_Protocolo == numeroProtocolo).ToListAsync();

            return mensagens;
        }

        public async Task<IEnumerable<Denuncia>> ObterProtocolosAbertos()
        {
            var protocolosAberto = await DbSet.Where(p => p.Status == "Aberto").ToListAsync();
            return protocolosAberto;
        }
    }
}
