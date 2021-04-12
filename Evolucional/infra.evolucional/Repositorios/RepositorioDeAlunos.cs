using domain.evolucional.Entidades;
using domain.evolucional.Repositorios;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace infra.evolucional.Repositorios
{
    public class RepositorioDeAlunos : Repositorio, IRepositorioDeAlunos
    {
        public RepositorioDeAlunos(IConfiguration configuration) : base(configuration) { }

        public void CadastrarAlunos(List<Aluno> alunos)
        {
            _ = this.ExecutarTruncateAsync("NOTAS").Result;
            _ = this.ExecutarTruncateAsync("MATRICULAS").Result;
            _ = this.ExecutarTruncateAsync("ALUNOS").Result;

            if (alunos.Any())
            {
                using (var data = new DataTable("ALUNOS"))
                {
                    data.Columns.Add("NOME", typeof(string));                    

                    alunos.ForEach(a =>
                    {                        
                        data.Rows.Add(data.NewRow()["NOME"] = a.Nome);
                    });

                    _ = this.ExecutarBulkAsync(data).Result;
                }
            }
        }

        public List<Aluno> RecuperarAlunos()
        {
            using (var reader = this.ExecutarQueryAsync("SELECT ID, NOME FROM DBO.[ALUNOS] WITH (NOLOCK)").Result)
            {
                var alunos = new List<Aluno>();

                while (reader.Read())
                {
                    alunos.Add(new Aluno
                    {
                        Id = reader.Int("ID"),
                        Nome = reader.String("NOME")
                    });
                }

                return (alunos);
            }
        }
    }
}