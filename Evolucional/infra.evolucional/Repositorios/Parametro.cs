namespace infra.evolucional.Repositorios
{
    public class Parametro
    {
        public string Nome { get; private set; }
        public object Valor { get; private set; }

        public Parametro(string nome, object valor)
        {
            this.Nome = nome.StartsWith("@") ? nome : $"@{nome}";
            this.Valor = valor;
        }
    }
}