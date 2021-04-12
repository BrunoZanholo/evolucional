using System.Collections.Generic;
using System.Linq;

namespace domain.evolucional.Dtos
{
    public class RelatorioNotas
    {
        public RelatorioNotas()
        {
            this.Notas = new List<Nota>();
            this.NomeAluno = string.Empty;
        }

        public string NomeAluno { get; set; }
        public decimal Media
        {
            get
            {
                return (this.Notas.Sum(n => n.Valor) / (this.Notas.Count * 1M));
            }
        }
        public List<Nota> Notas { get; set; }
    }
}