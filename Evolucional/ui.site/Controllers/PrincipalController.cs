using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;
using application.evolucional;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ui.evolucional.Models;

namespace ui.site.Controllers
{
    [Authorize]
    [Route("principal")]
    public class PrincipalController : Controller
    {        
        public IActionResult Index()
        {
            return View();
        }

        [Route("botao/1")]
        [HttpPost]
        public IActionResult Botao1(
            [FromServices] IGerarAlunos gerarAlunos,
            [FromServices] ICadastrarDisciplinas cadastrarDisciplinas,
            [FromServices] IMatricularAlunos matricularAlunos,
            [FromServices] IGerarNotasRandomicas gerarNotasRandomicas)
        {
            gerarAlunos.Gerar(1000);
            cadastrarDisciplinas.Cadastrar();
            matricularAlunos.Matricular();
            gerarNotasRandomicas.Gerar();

            return Json(new ResultadoModel { Mensagem = "Botão 1 executado com sucesso!" });
        }

        [Route("botao/2")]
        [HttpPost]
        public IActionResult Botao2([FromServices] IGerarRelatorioDeNotas gerarRelatorioDeNotas)
        {
            var relatorio = gerarRelatorioDeNotas.GerarRelatorioEmExcel();

            return Json(new ResultadoBotao2Model { Relatorio = relatorio, Mensagem = "Botão 2 executado com sucesso!" });
        }

        [Route("botao/2/dowload/{relatorio}")]
        [HttpGet]
        public IActionResult Botao2Download([FromServices] IConfiguration configuration, string relatorio)
        {
            var destino = configuration["Relatorios:Destino"];

            var root = AppDomain.CurrentDomain.GetData("ContentRootPath").ToString();            

            destino = root + destino + relatorio;

            return File(System.IO.File.OpenRead(destino), MediaTypeNames.Application.Octet, relatorio);
        }
    }
}