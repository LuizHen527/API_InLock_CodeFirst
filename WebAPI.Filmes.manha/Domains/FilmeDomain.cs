namespace WebAPI.Filmes.manha.Domains
{
    public class FilmeDomain
    {
        public int IdFilme { get; set; }
        public string Titulo { get; set; }

        public int IdGenero { get; set; }

        //Referencia classe genero
        public GeneroDomain? Genero { get; set; }
    }
}
