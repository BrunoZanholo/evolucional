using domain.evolucional.Repositorios;
using infra.evolucional.Repositorios;
using Microsoft.Extensions.DependencyInjection;

namespace infra.evolucional.ioc
{
    internal static class Infra
    {
        internal static void Aplicar(IServiceCollection services)
        {
            services.AddScoped<IRepositorioDeAlunos, RepositorioDeAlunos>();
            services.AddScoped<IRepositorioDeDisciplinas, RepositorioDeDisciplinas>();
            services.AddScoped<IRepositorioDeMatriculas, RepositorioDeMatriculas>();
            services.AddScoped<IRepositorioDeUsuarios, RepositorioDeUsuarios>();
            services.AddScoped<IRepositorioDeNotas, RepositorioDeNotas>();
        }
    }
}