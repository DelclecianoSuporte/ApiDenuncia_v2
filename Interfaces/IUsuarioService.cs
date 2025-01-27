using ApiDenuncia.DTO;

namespace ApiDenuncia.Interfaces
{
    public interface IUsuarioService
    {
        Task<UsuarioDTO> Incluir(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Alterar(UsuarioDTO usuarioDTO);
        Task<UsuarioDTO> Excluir(int id);
        Task<UsuarioDTO> RetornaUsuario(int id);
        Task<IEnumerable<UsuarioDTO>> RetornarTodosUsuarios();
    }
}
