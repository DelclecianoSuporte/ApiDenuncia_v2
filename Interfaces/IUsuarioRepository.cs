using ApiDenuncia.Models;

namespace ApiDenuncia.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario>Incluir(Usuario usuario);
        Task<Usuario>Alterar(Usuario usuario);
        Task<Usuario>Excluir(int id);
        Task<Usuario>RetornaUsuario(int id);
        Task<IEnumerable<Usuario>>RetornarTodosUsuarios();
    }
}
