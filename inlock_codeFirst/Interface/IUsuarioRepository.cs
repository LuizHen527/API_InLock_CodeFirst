using inlock_codeFirst.Domains;

namespace inlock_codeFirst.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDomain BuscarUsuario(string email, string senha);

        void Cadastrar(UsuarioDomain usuario);
    }
}
