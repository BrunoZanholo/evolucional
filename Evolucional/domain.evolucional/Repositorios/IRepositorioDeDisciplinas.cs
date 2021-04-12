using domain.evolucional.Entidades;
using System.Collections.Generic;

namespace domain.evolucional.Repositorios
{
    public interface IRepositorioDeDisciplinas
    {
        Disciplina RecuperarDisciplina(string nome);
        void CadastrarDisciplina(Disciplina disciplina);
        List<Disciplina> RecuperarDisciplinas();
    }
}