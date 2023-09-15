using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inlock_codeFirst.Domains
{
    [Table("TipoUsuario")]
    public class TipoUsuarioDomain
    {
        [Key]
        public Guid IdTipoUsuario { get; set; }

        [Column(TypeName = "VARCHAR(170)")]
        [Required(ErrorMessage = "Titulo obrigatorio")]
        public string? Titulo { get; set; }

        public List<UsuarioDomain>? Usuario { get; set; }
    }
}
