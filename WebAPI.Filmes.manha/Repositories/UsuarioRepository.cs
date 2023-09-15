using System.Data.SqlClient;
using System.Runtime.Intrinsics.Arm;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;

namespace WebAPI.Filmes.manha.Repositories
{

    /// <summary>
    /// Compara a senha e email digitada pelo usuario com as mesmas que estao no banco de dados.
    /// Se encontrar retorna um objeto com IdUsuario, Email, Senha e Permissao.
    /// Se nao encontrar retorna null.
    /// </summary>
    public class UsuarioRepository : IUsuarioRepository
    {
        private string StringConexao = "Data Source = NOTE22-S15; Initial Catalog = Filmes; User Id = sa; Pwd = Senai@134";

        public UsuarioDomain Login(string Email, string Senha)
        {
            using (SqlConnection con = new SqlConnection(StringConexao))
            {
                string queryLogin = "SELECT * FROM Usuario WHERE Email LIKE @Email AND Senha LIKE @Senha";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryLogin, con))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Senha", Senha);

                    cmd.ExecuteNonQuery();

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuario = new UsuarioDomain()
                        {
                            IdUsuario = Convert.ToInt32(rdr["IdUsuario"]),
                            Email = rdr["Email"].ToString(),
                            Senha = rdr["Senha"].ToString(),
                            Permissao = Convert.ToBoolean(rdr["Permissao"])

                        };

                        return usuario;
                    }

                    else
                    {
                        return null;
                    }
                }
            }
        }
    }
}
