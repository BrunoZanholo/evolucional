using domain.evolucional.Entidades;
using domain.evolucional.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace application.evolucional
{
    public class MatricularAlunos : IMatricularAlunos
    {
        private readonly IRepositorioDeMatriculas repositorioDeMatriculas;
        private readonly IRepositorioDeAlunos repositorioDeAlunos;
        private readonly IRepositorioDeDisciplinas repositorioDeDisciplinas;

        public MatricularAlunos(IRepositorioDeMatriculas repositorioDeMatriculas,
             IRepositorioDeAlunos repositorioDeAlunos,
             IRepositorioDeDisciplinas repositorioDeDisciplinas)
        {
            this.repositorioDeAlunos = repositorioDeAlunos;
            this.repositorioDeDisciplinas = repositorioDeDisciplinas;
            this.repositorioDeMatriculas = repositorioDeMatriculas;
        }

        public void Matricular()
        {
            var disciplinas = this.repositorioDeDisciplinas.RecuperarDisciplinas();

            var alunos = this.repositorioDeAlunos.RecuperarAlunos();

            var matriculas = new List<Matricula>(alunos.Count);

            alunos.ForEach(a =>
            {
                matriculas.Add(new Matricula { Aluno = a, Disciplinas = disciplinas });
            });

            this.repositorioDeMatriculas.MatricularAlunos(matriculas);
        }
    }
}