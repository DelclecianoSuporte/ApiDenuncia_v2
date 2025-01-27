using ApiDenuncia.Account;
using ApiDenuncia.Identity;
using ApiDenuncia.Interfaces;
using ApiDenuncia.Models;
using ApiDenuncia.Repository;
using ApiDenuncia.Services;
using Camada.Business.Interfaces;
using Camada.Business.Notificacoes;

namespace ApiDenuncia.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<Contexto>();
            services.AddScoped<INotificador, Notificador>();

            services.AddScoped<IDenunciaRepository, DenunciaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IDenunciaService, DenunciaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IAuthenticate, AuthenticateService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            return services;
        }
    }
}
