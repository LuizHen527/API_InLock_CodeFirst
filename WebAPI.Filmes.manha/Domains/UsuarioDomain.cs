using System.ComponentModel.DataAnnotations;

namespace WebAPI.Filmes.manha.Domains
{

    /// <summary>
    /// Classe que representa a entidade Usuario
    /// </summary>

    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }
        [Required(ErrorMessage = "O campo Email e obrigatorio")]
        public string Email { get; set; }

        [StringLength(20,MinimumLength =3, ErrorMessage ="A senha precisa de mais caracteres")]
        [Required(ErrorMessage = "O campo senha e obrigatorio")]
        public string Senha { get; set; }

        public bool Permissao { get; set; }
    }
}
