using System.ComponentModel.DataAnnotations;

namespace ui.site.Models
{
    public class LoginModel
    {        
        public string ReturnUrl { get; set; }
        [Required(ErrorMessage = "O úsuário é requerido")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "A senha é requerida")] 
        public string Senha { get; set; }
    }
}