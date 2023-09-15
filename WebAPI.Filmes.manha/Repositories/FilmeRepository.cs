using System.Data.SqlClient;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;


namespace WebAPI.Filmes.manha.Repositories
{
    public class FilmeRepository : IFilmeRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";


        /// <summary>
        /// Metodo que atualiza um filme pelo seu corpo
        /// </summary>
        /// <param name="filme">Objeto filme que sera colocado no lugar do antigo filme</param>

        public void AtualizarIdCorpo(FilmeDomain filme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateByBody = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryUpdateByBody, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", filme.IdFilme);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Atualiza um filme passando seu id pela Url
        /// </summary>
        /// <param name="id">Id do filme que sera atualizado</param>
        /// <param name="filme">Objeto do filme que sera atualizado</param>

        public void AtualizarIdUrl(int id, FilmeDomain filme)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdateByUrl = "UPDATE Filme SET Titulo = @Titulo, IdGenero = @IdGenero WHERE IdFilme = @IdFilme";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdateByUrl, con))
                {
                    cmd.Parameters.AddWithValue("@Titulo", filme.Titulo);
                    cmd.Parameters.AddWithValue("@IdGenero", filme.IdGenero);
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um filme por seu Id
        /// </summary>
        /// <param name="id">Id que sera usado para encontrar o objeto</param>
        /// <returns>Retorna o Filme encontrado</returns>

        public FilmeDomain BuscarPorId(int id)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectById = "SELECT * FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                SqlDataReader rdr;

                using(SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain
                        {
                            IdFilme = Convert.ToInt32(rdr["IdFilme"]),
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        return filme;
                    }

                    else
                    {
                        return null;
                    }
                }
            }
        }

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Filme que sera cadastrado</param>

        public void Cadastrar(FilmeDomain novoFilme)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryInsert = "INSERT INTO Filme (IdGenero, Titulo) VALUES(@IdGenero, @Titulo)";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", novoFilme.IdGenero);
                    cmd.Parameters.AddWithValue("@Titulo", novoFilme.Titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deleta um filme existente
        /// </summary>
        /// <param name="id">Id do filme que sera deletado</param>

        public void Deletar(int id)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Filme WHERE IdFilme = @IdFilme";

                con.Open();

                using(SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdFilme", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Retorna uma lista com todos os filmes</returns>

        public List<FilmeDomain> ListarTodos()
        {
            List<FilmeDomain> listaFilme = new List<FilmeDomain>();

            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Filme ";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FilmeDomain filme = new FilmeDomain()
                        {
                            IdFilme = Convert.ToInt32(rdr[0]),
                            IdGenero = Convert.ToInt32(rdr[0]),
                            Titulo = rdr["Titulo"].ToString()
                        };

                        listaFilme.Add(filme);
                    }
                }
            }

            return listaFilme;
        }


    }
}
