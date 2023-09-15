using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace inlock_codeFirst.Domains
{
    [Table("Jogo")]
    public class JogoDomain
    {
        [Key]
        public Guid IdJogo { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(150)")]
        [Required(ErrorMessage = "Nome jogo obrigatorio")]
        public string Nome { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "Descricao obrigatorio")]
        public string Descricao { get; set; }

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "Date release obrigatoria")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "Decimal(4,2)")]
        [Required(ErrorMessage = "Preco obrigatorio")]
        public decimal Preco { get; set; }

        //Referencia da chave estrangeira na tabela de Estudio

        [Required(ErrorMessage = "Informe o estudio que produziu o jogo obrigatorio")]
        public Guid IdEstudio { get; set; }

        [ForeignKey("IdEstudio")]
        public EstudioDomain? Estudio { get; set; }
    }
}
