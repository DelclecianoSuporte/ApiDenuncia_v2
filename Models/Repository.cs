using ApiDenuncia.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ApiDenuncia.Models
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly Contexto Db;
        protected readonly DbSet<TEntity> DbSet;

        public Repository(Contexto db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<List<TEntity>> ObterProtocolosAbertos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<TEntity>> ObterTodosProtocolos()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
