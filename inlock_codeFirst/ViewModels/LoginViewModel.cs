using System.ComponentModel.DataAnnotations;

namespace inlock_codeFirst.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email obrigatorio")]
        public string? email { get; set; }

        [Required(ErrorMessage = "Senha obrigatorio")]
        public string? senha { get; set; }    
    }
}
