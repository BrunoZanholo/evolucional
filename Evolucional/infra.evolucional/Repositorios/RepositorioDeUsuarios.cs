using domain.evolucional.Entidades;
using domain.evolucional.Repositorios;
using Microsoft.Extensions.Configuration;

namespace infra.evolucional.Repositorios
{
    public class RepositorioDeUsuarios : Repositorio, IRepositorioDeUsuarios
    {
        public RepositorioDeUsuarios(IConfiguration configuration) : base(configuration) { }

        public Usuario RecuperarUsuario(string login, string senha)
        {
            using (var reader = this.ExecutarQueryAsync("SELECT ID FROM DBO.[USUARIOS] WITH (NOLOCK) WHERE [LOGIN] = @LOGIN AND [PASS] = @PASS;", new Parametro("@LOGIN", login), new Parametro("@PASS", senha)).Result)
            {
                if (reader.Read())
                {
                    return (new Usuario
                    {
                        Id = reader.Int("ID"),
                        Login = login
                    });
                }

                return (null);
            }
        }
    }
}