using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace domain.evolucional.Entidades
{
    public class Usuario : Base
    {
        public string Login { get; set; }

        public bool Ativo { get; set; }
        
        public static string CriptografarSenha(string conteudo)
        {
            var hash = new StringBuilder();

            conteudo += "chave-evolucional";

            MD5.Create().ComputeHash(Encoding.Default.GetBytes(conteudo)).ToList().ForEach(item =>
            {
                hash.Append(item.ToString("x2"));
            });

            return (hash.ToString());
        }
    }
}