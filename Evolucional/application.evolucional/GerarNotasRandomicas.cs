using domain.evolucional.Repositorios;

namespace application.evolucional
{
    public class GerarNotasRandomicas : IGerarNotasRandomicas
    {
        private readonly IRepositorioDeNotas repositorioDeNotas;

        public GerarNotasRandomicas(IRepositorioDeNotas repositorioDeNotas)
        {
            this.repositorioDeNotas = repositorioDeNotas;
        }

        public void Gerar()
        {
            this.repositorioDeNotas.GerarNotasRandomicas();
        }
    }
}