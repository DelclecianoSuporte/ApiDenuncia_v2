using ApiDenuncia.DTO;
using ApiDenuncia.Models;
using ApiDenuncia.ViewModel;
using AutoMapper;

namespace ApiDenuncia.Configurations
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig() 
        {
            CreateMap<DenunciaViewModel, Denuncia>().ReverseMap();
            CreateMap<Usuario, UsuarioDTO>().ReverseMap();
        }
    }
}
