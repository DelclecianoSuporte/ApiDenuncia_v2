using ApiDenuncia.Account;
using ApiDenuncia.DTO;
using ApiDenuncia.Interfaces;
using ApiDenuncia.Models;
using Camada.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiDenuncia.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : MainController
    {
        private readonly IAuthenticate _authenticateService;
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IAuthenticate authenticateService, IUsuarioService usuarioService, INotificador notificador) : base(notificador)
        {
            _authenticateService = authenticateService;
            _usuarioService = usuarioService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UsuarioDTO usuarioDTO) 
        {
            if(usuarioDTO == null) 
            {
                return BadRequest("Dados inválidos");
            }

            var emailExiste = await _authenticateService.UserExists(usuarioDTO.Email);

            if (emailExiste) 
            {
                return BadRequest("Este e-mail já possui um cadastro.");
            }

            var usuario = await _usuarioService.Incluir(usuarioDTO);

            if(usuario == null)
            {
                return BadRequest("Ocorreu um erro ao cadastrar.");
            }

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel)
        {
            var existe = await _authenticateService.UserExists(loginModel.Email);
            
            if (!existe) 
            {
                return Unauthorized("Usuário não existe.");
            }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            
            if(!result)
            {
                return Unauthorized("Usário ou senha inválido.");
            }

            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);
            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken
            {
                Token = token
            };
        }


    }
}
