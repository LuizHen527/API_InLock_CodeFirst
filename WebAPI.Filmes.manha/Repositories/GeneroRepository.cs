using System.Data.SqlClient;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;

namespace WebAPI.Filmes.manha.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";
        //User Id = sa; Pwd = Senha;
        //Data Source = Nome do
        public void AtualizarIdCorpo(GeneroDomain genero)
        {
            using(SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @NovoNome WHERE IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con))
                {
                    cmd.Parameters.AddWithValue("@NovoNome", genero.Nome);
                    cmd.Parameters.AddWithValue("@IdGenero", genero.IdGenero);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AtualizarIdUrl(int id, GeneroDomain genero)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryUpdate = "UPDATE Genero SET Nome = @NovoNome WHERE IdGenero = @IdGenero";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryUpdate, con)) 
                {

                    cmd.Parameters.AddWithValue("@IdGenero", id);
                    cmd.Parameters.AddWithValue("@NovoNome", genero.Nome);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Busca um genero por um Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public GeneroDomain BuscarPorId(int id)
        {

            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT * FROM Genero WHERE IdGenero = @IdGenero";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //cmd.Parameters.AddWithValue("@IdGenero", id);

                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade Idgenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr["IdGenero"]),
                            //Atribui a propriedade nome um valor
                            Nome = rdr["Nome"].ToString()
                        };

                        return genero;
                    }

                    else
                    {
                        return null;
                    }

                    

                    
                }
            }

            
        }

        /// <summary>
        /// Cadastrar um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto com as informacoes a serem cadastradas</param>

        public void Cadastrar(GeneroDomain novoGenero)
        {
            //Conecta ao banco de dados
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                //Consulta sql
                string queryInsert = "INSERT INTO Genero (Nome) VALUES(@Nome)";
                //Sql Command passando a query a ser executada e a conexao com o db
                using (SqlCommand cmd = new SqlCommand(queryInsert, con)) 
                {

                    cmd.Parameters.AddWithValue("@Nome", novoGenero.Nome);
                    //Abre conexao com o banco de dados 
                    con.Open();
                    //Executar a query
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Deletar(int id)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryDelete = "DELETE FROM Genero WHERE IdGenero = @IdGenero";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@IdGenero", id);

                    con.Open() ;

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Listar todos os objetos generos
        /// </summary>
        /// <returns>Retorna uma lista de objetos</returns>

        public List<GeneroDomain> ListarTodos()
        {
            //Cria uma lista de objetos tipo genero
            List<GeneroDomain> listaGenero = new List<GeneroDomain>();

            //Passando a string de conexao com parametro
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string querySelectAll = "SELECT IdGenero, Nome FROM Genero";
                //Abre conexao com o banco de dados 
                con.Open();
                //Declara o SqlDataReader para percorrer o banco de dados 
                SqlDataReader rdr;
                //Declara o SqlCommand passando a Query do Sql e a String de conexao
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa query e armazena os dados no rdr
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //atribui a propriedade Idgenero o valor recebido no rdr
                            IdGenero = Convert.ToInt32(rdr[0]),
                            //Atribui a propriedade nome um valor
                            Nome = rdr["Nome"].ToString()
                        };
                        //Adiciona cada objeto dentro da lista
                        listaGenero.Add(genero);
                    }
                }
            }

            return listaGenero;
        }
    }
}
