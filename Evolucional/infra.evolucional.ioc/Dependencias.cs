using Microsoft.Extensions.DependencyInjection;
using System;

namespace infra.evolucional.ioc
{
    public static class Dependencias
    {        
        public static void Aplicar(IServiceCollection services)
        {
            Application.Aplicar(services);
            Domain.Aplicar(services);
            Infra.Aplicar(services);
        }        
    }
}