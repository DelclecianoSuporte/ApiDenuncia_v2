using ApiDenuncia.Models;

namespace ApiDenuncia.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : Entity
    {
        Task Adicionar(TEntity entity);
        Task<int> SaveChanges();
        Task<List<TEntity>> ObterTodosProtocolos();
        Task<List<TEntity>> ObterProtocolosAbertos();
    }
}
