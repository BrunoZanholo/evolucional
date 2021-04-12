using domain.evolucional.Entidades;
using domain.evolucional.Repositorios;

namespace application.evolucional
{
    public class CadastrarDisciplinas : ICadastrarDisciplinas
    {
        private readonly IRepositorioDeDisciplinas repositorioDeDisciplinas;

        public CadastrarDisciplinas(IRepositorioDeDisciplinas repositorioDeDisciplinas)
        {
            this.repositorioDeDisciplinas = repositorioDeDisciplinas;
        }

        public void Cadastrar()
        {
            for (var i = 0; i < Disciplina.Disciplinas.Count; i++)
            {
                if (this.repositorioDeDisciplinas.RecuperarDisciplina(Disciplina.Disciplinas[i]) == null)
                {
                    this.repositorioDeDisciplinas.CadastrarDisciplina(new Disciplina { Nome = Disciplina.Disciplinas[i] });
                }
            }
        }
    }
}