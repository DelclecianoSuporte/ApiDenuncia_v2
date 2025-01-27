using Microsoft.EntityFrameworkCore;

namespace ApiDenuncia.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options){}

        public DbSet<Denuncia> Denuncias { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
