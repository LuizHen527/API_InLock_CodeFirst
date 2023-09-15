using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inlock_codeFirst.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email),IsUnique=true)]//Cria indice unico para 
    public class UsuarioDomain
    {
        [Key]
        public Guid IdUsuario { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Email obrigatorio")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "Senha obrigatoria")]
        [StringLength(200, MinimumLength = 6, ErrorMessage = "Senha deve conter minimo de 6")]

        public string? Senha { get; set; }

        [Required(ErrorMessage = "Tipo do usuario obrigatorio")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TipoUsuarioDomain? TipoUsuario { get; set; }


    }
}
