using domain.evolucional.Dtos;
using System.Collections.Generic;

namespace domain.evolucional.Repositorios
{
    public interface IRepositorioDeNotas
    {
        void GerarNotasRandomicas();

        List<RelatorioNotas> RecuperarNotas();
    }
}