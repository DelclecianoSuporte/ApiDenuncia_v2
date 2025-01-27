using ApiDenuncia.Interfaces;
using ApiDenuncia.Models;

namespace ApiDenuncia.Services
{
    public class DenunciaService : IDenunciaService
    {
        private readonly IDenunciaRepository _denunciaRepository;

        public DenunciaService(IDenunciaRepository denunciaRepository)
        {
            _denunciaRepository = denunciaRepository;
        }

        public async Task Adicionar(Denuncia denuncia)
        {
            await _denunciaRepository.Adicionar(denuncia);
        }

        public async Task<IEnumerable<Denuncia>> ObterTodosProtocolos()
        {
           return await _denunciaRepository.ObterTodosProtocolos();
        }
    }
}
