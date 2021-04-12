using domain.evolucional.Entidades;
using domain.evolucional.Repositorios;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace infra.evolucional.Repositorios
{
    public class RepositorioDeDisciplinas : Repositorio, IRepositorioDeDisciplinas
    {
        public RepositorioDeDisciplinas(IConfiguration configuration) : base(configuration) { }

        public void CadastrarDisciplina(Disciplina disciplina)
        {
            using (var reader = this.ExecutarQueryAsync("INSERT INTO DBO.[DISCIPLINAS] ([NOME]) VALUES (@NOME); SELECT SCOPE_IDENTITY() AS ID;", new Parametro("@NOME", disciplina.Nome)).Result)
            {
                if (reader.Read())
                {
                    disciplina.Id = reader.Int("ID");
                }
            }
        }

        public Disciplina RecuperarDisciplina(string nome)
        {
            using (var reader = this.ExecutarQueryAsync("SELECT ID, NOME FROM DBO.[DISCIPLINAS] WITH (NOLOCK) WHERE [NOME] = @NOME;", new Parametro("@NOME", nome)).Result)
            {
                if (reader.Read())
                {
                    return (new Disciplina
                    {
                        Id = reader.Int("ID"),
                        Nome = reader.String("NOME")
                    });
                }

                return (null);
            }
        }

        public List<Disciplina> RecuperarDisciplinas()
        {
            using (var reader = this.ExecutarQueryAsync("SELECT ID, NOME FROM DBO.[DISCIPLINAS] WITH (NOLOCK)").Result)
            {
                var disciplinas = new List<Disciplina>();

                while (reader.Read())
                {
                    disciplinas.Add(new Disciplina
                    {
                        Id = reader.Int("ID"),
                        Nome = reader.String("NOME")
                    });
                }

                return (disciplinas);
            }
        }
    }
}