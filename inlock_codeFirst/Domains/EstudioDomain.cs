using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inlock_codeFirst.Domains
{
    [Table("Estudio")]
    public class EstudioDomain
    {
        [Key]
        public Guid IdEstudio { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Nome estudio obrigatorio")]
        public string? Nome { get; set; }

        public List<JogoDomain>? Jogo { get; set; }
    } 
}
