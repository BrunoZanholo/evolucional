using domain.evolucional.Entidades;
using domain.evolucional.Repositorios;
using System.Collections.Generic;
using System.Linq;

namespace application.evolucional
{
    public class GerarAlunos : IGerarAlunos
    {
        private readonly IRepositorioDeAlunos repositorioDeAlunos;

        public GerarAlunos(IRepositorioDeAlunos repositorioDeAlunos)
        {
            this.repositorioDeAlunos = repositorioDeAlunos;
        }

        public void Gerar(int quantidade)
        {
            var alunos = new List<Aluno>(quantidade);

            while (alunos.Count < 1000)
            {
                var aluno = new Aluno();

                if (!alunos.Any(a => aluno.Nome == a.Nome))
                {
                    alunos.Add(new Aluno());
                }

            }

            this.repositorioDeAlunos.CadastrarAlunos(alunos);
        }
    }
}