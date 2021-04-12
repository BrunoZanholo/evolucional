using domain.evolucional.Entidades;
using domain.evolucional.Repositorios;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace infra.evolucional.Repositorios
{
    public class RepositorioDeMatriculas : Repositorio, IRepositorioDeMatriculas
    {
        public RepositorioDeMatriculas(IConfiguration configuration) : base(configuration) { }

        public void MatricularAlunos(List<Matricula> matriculas)
        {           
            if (matriculas.Any())
            {
                using (var data = new DataTable("MATRICULAS"))
                {
                    data.Columns.Add("ALUNO_ID", typeof(int));
                    data.Columns.Add("DISCIPLINA_ID", typeof(int));

                    matriculas.ForEach(m =>
                    {
                        m.Disciplinas.ForEach(d =>
                        {
                            var row = data.NewRow();

                            row["ALUNO_ID"] = m.Aluno.Id;
                            row["DISCIPLINA_ID"] = d.Id;

                            data.Rows.Add(row);
                        });
                    });

                    _ = this.ExecutarBulkAsync(data).Result;
                }
            }
        }
    }
}