using ClosedXML.Excel;
using domain.evolucional.Repositorios;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace application.evolucional
{
    public class GerarRelatorioDeNotas : IGerarRelatorioDeNotas
    {
        private readonly IConfiguration configuration;
        private readonly IRepositorioDeNotas repositorioDeNotas;

        public GerarRelatorioDeNotas(
            IConfiguration configuration,
            IRepositorioDeNotas repositorioDeNotas)
        {
            this.configuration = configuration;
            this.repositorioDeNotas = repositorioDeNotas;
        }

        public string GerarRelatorioEmExcel()
        {
            var data = DateTime.Now;

            var relatorio = this.repositorioDeNotas.RecuperarNotas();

            var template = this.configuration["Relatorios:Templates:Notas"];
            var destino = this.configuration["Relatorios:Destino"];

            var root = AppDomain.CurrentDomain.GetData("ContentRootPath").ToString();            

            template = root + template;

            destino = root + destino + $"notas-{data.ToString("ddmmyyyy-HHmmssfff")}.xlsx";

            File.Copy(template, destino);

            using (var workbook = new XLWorkbook(destino))
            {
                var worksheet = workbook.Worksheets.Worksheet("Relatório");

                worksheet.Cell("K2").Value = data.ToString();

                var cel = worksheet.Cell("A" + (5));

                relatorio[0].Notas.ForEach(n =>
                {
                    cel = cel.CellRight();
                    cel.Value = n.Disciplina;
                });

                for (var i = 0; i < relatorio.Count; i++)
                {
                    var rel = relatorio[i];

                    cel = worksheet.Cell("A" + (6 + i));

                    cel.Value = rel.NomeAluno;

                    rel.Notas.ForEach(n =>
                    {
                        cel = cel.CellRight();
                        cel.Value = n.Valor;
                    });

                    cel = cel.CellRight();
                    cel.Value = rel.Media;
                }
                
                workbook.Save();
            }

            return ($"notas-{data.ToString("ddmmyyyy-HHmmssfff")}.xlsx");
        }
    }
}