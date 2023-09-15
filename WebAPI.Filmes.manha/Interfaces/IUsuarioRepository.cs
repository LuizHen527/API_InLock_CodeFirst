using WebAPI.Filmes.manha.Domains;

namespace WebAPI.Filmes.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        UsuarioDomain Login(string Email, string Senha);

    }
}
