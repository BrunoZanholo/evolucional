namespace application.evolucional
{
    public interface IAutenticarUsuario
    {
        bool Autenticar(string login, string senha);
    }
}