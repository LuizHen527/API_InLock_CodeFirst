using System.ComponentModel.DataAnnotations;

namespace WebAPI.Filmes.manha.Domains
{
    /// <summary>
    /// Classe que representa a entidade genero
    /// </summary>
    public class GeneroDomain
    {
        public int IdGenero { get; set; }


        [Required (ErrorMessage = "Nome do genero necessario")]

        public string? Nome { get; set; }
    }
}
