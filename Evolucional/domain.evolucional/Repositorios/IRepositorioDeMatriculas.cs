using domain.evolucional.Entidades;
using System.Collections.Generic;

namespace domain.evolucional.Repositorios
{
    public interface IRepositorioDeMatriculas
    {
        void MatricularAlunos(List<Matricula> matriculas);        
    }
}