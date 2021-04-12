using System.Collections.Generic;

namespace domain.evolucional.Entidades
{
    public class Disciplina : Base
    {
        public string Nome { get; set; }

        public static List<string> Disciplinas = new List<string>()
        {
            "Matemática",
            "Português",
            "História",
            "Geografia",
            "Inglês",
            "Biologia",
            "FIlosofia",
            "Física",
            "Química"
        };
    }
}