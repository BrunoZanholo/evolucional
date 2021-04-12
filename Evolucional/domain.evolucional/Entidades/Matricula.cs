using System;
using System.Collections.Generic;
using System.Text;

namespace domain.evolucional.Entidades
{
    public class Matricula : Base
    {
        public Aluno Aluno { get; set; }

        public List<Disciplina> Disciplinas { get; set; }
    }
}