using inlock_codeFirst.Context;
using inlock_codeFirst.Domains;
using inlock_codeFirst.Interface;
using inlock_codeFirst.Utils;

namespace inlock_codeFirst.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Variavel privada somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InLockContext? ctx;

        /// <summary>
        /// Ctor que tera acesso toda vez que o repositorio for instanciado, ele tera acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InLockContext();
        }
        public UsuarioDomain BuscarUsuario(string email, string senha)
        {
            try
            {
                UsuarioDomain usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email)!;

                if(usuarioBuscado != null)
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if(confere)
                    {
                        return usuarioBuscado;
                    }
                }

                return null!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Cadastrar(UsuarioDomain usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Usuario.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
