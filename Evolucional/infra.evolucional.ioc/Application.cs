using application.evolucional;
using Microsoft.Extensions.DependencyInjection;

namespace infra.evolucional.ioc
{
    internal static class Application
    {
        internal static void Aplicar(IServiceCollection services)
        {
            services.AddScoped<IAutenticarUsuario, AutenticarUsuario>();
            services.AddScoped<IGerarAlunos, GerarAlunos>();
            services.AddScoped<ICadastrarDisciplinas, CadastrarDisciplinas>();
            services.AddScoped<IMatricularAlunos, MatricularAlunos>();
            services.AddScoped<IGerarNotasRandomicas, GerarNotasRandomicas>();
            services.AddScoped<IGerarRelatorioDeNotas, GerarRelatorioDeNotas>();            
        }
    }
}