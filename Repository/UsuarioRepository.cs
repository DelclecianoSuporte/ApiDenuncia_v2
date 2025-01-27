using ApiDenuncia.Interfaces;
using ApiDenuncia.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiDenuncia.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;

        public UsuarioRepository(Contexto contexto) 
        {
            _contexto = contexto;
        }

        public async Task<Usuario> Alterar(Usuario usuario)
        {
           _contexto.Usuario.Update(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Excluir(int id)
        {
            var usuario = await _contexto.Usuario.FindAsync(id);
            
            if(usuario != null) 
            {
                _contexto.Usuario.Remove(usuario);
                await _contexto.SaveChangesAsync(); 
                return usuario;
            }

            return null;
        }

        public async Task<Usuario> Incluir(Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            await _contexto.SaveChangesAsync();
            return usuario;
        }

        public async Task<IEnumerable<Usuario>> RetornarTodosUsuarios()
        {
            return await _contexto.Usuario.ToListAsync();
        }

        public async Task<Usuario> RetornaUsuario(int id)
        {
            return await _contexto.Usuario.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
