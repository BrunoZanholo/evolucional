using System;
using System.Collections.Generic;
using System.Text;

namespace domain.evolucional.Entidades
{
    public class Aluno : Base
    {
        public Aluno()
        {
            this.GerarNome();
        }

        public string Nome { get; set; }

        private void GerarNome()
        {
            if (string.IsNullOrEmpty(this.Nome))
            {
                var random = new Random();                

                this.Nome = Nomes[random.Next(0, (Nomes.Count - 1))];

                var nomes = random.Next(1, 2);

                for (int i = 1; i < nomes; i++)
                {
                    var aux = Nomes[random.Next(0, (Nomes.Count - 1))];

                    if (!this.Nome.EndsWith(aux))
                    {
                        this.Nome += " " + aux;
                    }
                }

                this.Nome += " " + Sobrenomes[random.Next(0, (Sobrenomes.Count - 1))];

                var sobrenomes = random.Next(2, 5);

                for (int i = 1; i < sobrenomes; i++)
                {
                    var aux = Sobrenomes[random.Next(0, (Sobrenomes.Count - 1))];

                    if (!this.Nome.EndsWith(aux))
                    {
                        this.Nome += " " + aux;
                    }
                }
            }
        }

        private static List<string> Sobrenomes = new List<string>()
        {
            "Almeida",
            "Silva",
            "Cruz",
            "Oliveira",
            "Prado",
            "Santos",
            "Souza",
            "Rodrigues",
            "Ferreira",
            "Alves",
            "Pereira",
            "Lima",
            "Gomes",
            "Costa",
            "Ribeiro",
            "Matinez",
            "Martins",
            "Lopes",
            "Soares",
            "Fernandes",
            "Vieira",
            "Barbosa",
            "Ruiz",
            "Rocha",
            "Dias",
            "Nascimento",
            "Medeiros",
            "Andrade",
            "Nunes",
            "Mendes",
            "Freitas",
            "Cardoso",
            "Ramos",
            "Teixeira",
            "Alves",
            "Alvarez",
            "Araujo",
            "Aragão",
            "Batista",
            "Camargo",
            "Carmo",
            "Coelho",
            "Couto",
            "Fonseca",
            "Frota",
            "Furtado",
            "Garcia",
            "Moura",
            "Mesquita",
            "Alencar",
            "Osorio",
            "Pena",
            "Polo",
            "Navarro",
            "Takashi",
            "Brandão",
            "Xavier",
            "Hiroshi",
            "Guaira",
            "Coutinho",
            "Pelegrini",
            "Goulart",
            "Lazaro",
            "Leite",
            "Villa",
            "Rezende",
            "Franca",
            "Maciel",
            "Marçal",
            "Peres",
            "Chaves",
            "Rampasso",
            "Bonfim",
            "Cerávolo",
            "Maia",
            "Sales",
            "Mazini",
            "Evangelista",
            "Alonso"
        };

        private static List<string> Nomes = new List<string>()
        {
            "Alexandre",
            "Eduardo",
            "Henrique",
            "Murilo",
            "André",
            "Tiago",
            "Antônio",
            "Otávio",
            "Augusto",
            "Pietro",
            "Vicente",
            "Felipe",
            "João",
            "Rafael",
            "Vinícius",
            "Bruno",
            "Fernando",
            "Vitor",
            "Caio",
            "Francisco",
            "Leonardo",
            "Frederico",
            "Luan",
            "Ricardo",
            "Daniel",
            "Guilherme",
            "Lucas",
            "Rodrigo",
            "Camila",
            "Natália",
            "Carolina",
            "Fernanda",
            "Joana",
            "Nicole",
            "Amanda",
            "Catarina",
            "Gabriela",
            "Laís",
            "Maria",
            "Gabriele",
            "Lara",
            "Clara",
            "Giovana",
            "Larissa",
            "Mariana",
            "Rafaela",
            "Marina",
            "Rebeca",
            "Bárbara",
            "Eduarda",
            "Letícia",
            "Beatriz",
            "Elisa",
            "Vitória",
            "Igor",
            "Túlio",
            "Ricardo",
            "Diórges",
            "Taís",
            "Sara",
            "Roseli",
            "Aparecida",
            "Patricio",
            "Muriel",
            "Mariano",
            "Lara",
            "Camilo",
            "Juliano",
            "Elder",
            "Graziele"
        };
    }
}