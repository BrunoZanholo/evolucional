namespace ui.evolucional.Models
{
    public class ResultadoModel
    {
        public ResultadoModel()
        {
            this.Erro = false;
        }

        public bool Erro { get; set; }
        public string Mensagem { get; set; }
    }
}