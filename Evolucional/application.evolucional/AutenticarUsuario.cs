using domain.evolucional.Entidades;
using domain.evolucional.Repositorios;

namespace application.evolucional
{
    public class AutenticarUsuario : IAutenticarUsuario
    {
        private readonly IRepositorioDeUsuarios repositorioDeUsuarios;

        public AutenticarUsuario(IRepositorioDeUsuarios repositorioDeUsuarios)
        {
            this.repositorioDeUsuarios = repositorioDeUsuarios;
        }

        public bool Autenticar(string login, string senha)
        {   
            return (this.repositorioDeUsuarios.RecuperarUsuario(login, Usuario.CriptografarSenha(senha)) != null);
        }
    }
}