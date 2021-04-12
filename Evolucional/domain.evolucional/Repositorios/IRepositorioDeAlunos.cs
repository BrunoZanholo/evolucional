using domain.evolucional.Entidades;
using System.Collections.Generic;

namespace domain.evolucional.Repositorios
{
    public interface IRepositorioDeAlunos
    {
        void CadastrarAlunos(List<Aluno> alunos);

        List<Aluno> RecuperarAlunos();
    }
}