using WebAPI.Filmes.manha.Domains;

namespace WebAPI.Filmes.manha.Interfaces
{
    public interface IFilmeRepository
    {
        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoFilme">Objeto que sera cadastrado</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Listar todos os objetos cadastrados 
        /// </summary>
        /// <returns>Lista com os objetos</returns>

        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="filme">Objeto atualizado (Novas informacoes)</param>

        void AtualizarIdCorpo(FilmeDomain filme);

        /// <summary>
        /// Atualiza objeto existente passando id pela url
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado</param>
        /// <param name="filme">Objeto atualizado(novas informacoes)</param>

        void AtualizarIdUrl(int id, FilmeDomain filme);

        /// <summary>
        /// Deletar um objeto
        /// </summary>
        /// <param name="id">Id do objeto que sera deletado</param>

        void Deletar(int id);

        /// <summary>
        /// Buscar objeto por seu id
        /// </summary>
        /// <param name="id">Id do objeto a ser buscado</param>
        /// <returns>Objeto buscado</returns>

        FilmeDomain BuscarPorId(int id);
    }
}
