using domain.evolucional.Entidades;

namespace domain.evolucional.Repositorios
{
    public interface IRepositorioDeUsuarios
    {
        Usuario RecuperarUsuario(string login, string senha);
    }
}