using domain.evolucional.Dtos;
using domain.evolucional.Repositorios;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace infra.evolucional.Repositorios
{
    public class RepositorioDeNotas : Repositorio, IRepositorioDeNotas
    {
        public RepositorioDeNotas(IConfiguration configuration) : base(configuration) { }

        public void GerarNotasRandomicas()
        {         
            var sql = new StringBuilder();
            sql.AppendLine("INSERT INTO DBO.[NOTAS] ([MATRICULA_ID], [NOTA])");
            sql.AppendLine("SELECT M.ID, CAST(CAST(ABS(CHECKSUM(NEWID())) % 1000 AS NUMERIC(6,2))/100 AS NUMERIC(4,2)) AS NOTA");
            sql.AppendLine("FROM DBO.[MATRICULAS] M WITH (NOLOCK)");
            sql.AppendLine("LEFT JOIN DBO.[NOTAS] N WITH (NOLOCK) ON N.[MATRICULA_ID] = M.[ID]");
            sql.AppendLine("WHERE N.[MATRICULA_ID] IS NULL ");

            _ = this.ExecutarCommandoAsync(sql.ToString()).Result;
        }

        public List<RelatorioNotas> RecuperarNotas()
        {
            var sql = new StringBuilder();
            sql.AppendLine("SELECT A.[NOME] AS [ALUNO], D.[NOME] AS [DISCIPLINA], N.[NOTA]");
            sql.AppendLine("FROM DBO.[MATRICULAS] M WITH (NOLOCK)");
            sql.AppendLine("INNER JOIN DBO.[ALUNOS] A WITH (NOLOCK) ON A.[ID] = M.[ALUNO_ID]");
            sql.AppendLine("INNER JOIN DBO.[DISCIPLINAS] D WITH (NOLOCK) ON D.[ID] = M.[DISCIPLINA_ID]");
            sql.AppendLine("INNER JOIN DBO.[NOTAS] N WITH (NOLOCK) ON N.[MATRICULA_ID] = M.[ID]");
            sql.AppendLine("ORDER BY A.[NOME] ASC");

            using (var reader = this.ExecutarQueryAsync(sql.ToString()).Result)
            {
                var relatorio = new List<RelatorioNotas>();

                var rel = new RelatorioNotas();

                while (reader.Read())
                {
                    var aluno = reader.String("ALUNO");

                    if (!string.Equals(aluno, rel.NomeAluno, StringComparison.OrdinalIgnoreCase))
                    {
                        rel = new RelatorioNotas { NomeAluno = aluno };

                        relatorio.Add(rel);
                    }

                    rel.Notas.Add(new Nota { Disciplina = reader.String("DISCIPLINA"), Valor = reader.Decimal("NOTA") });
                }

                return (relatorio);
            }
        }
    }
}