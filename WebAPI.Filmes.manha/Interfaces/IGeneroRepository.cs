using WebAPI.Filmes.manha.Domains;

namespace WebAPI.Filmes.manha.Interfaces
{

    /// <summary>
    /// Interface responsavel pelo repositorio GeneroRepository
    /// Definir os metodos que serao implementados pelo GeneroRepository
    /// </summary>
    public interface IGeneroRepository
    {
        
        /// <summary>
        /// Cadastra um novo genero
        /// </summary>
        /// <param name="novoGenero">Objeto que sera cadastrado</param>

        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Listar todos os objetos cadastrados 
        /// </summary>
        /// <returns>Lista com os objetos</returns>

        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Atualizar objeto existente passando seu id pelo corpo da requisicao
        /// </summary>
        /// <param name="genero">Objeto atualizado (Novas informacoes)</param>

        void AtualizarIdCorpo(GeneroDomain genero);

        /// <summary>
        /// Atualiza objeto existente passando id pela url
        /// </summary>
        /// <param name="id">Id do objeto que sera atualizado</param>
        /// <param name="genero">Objeto atualizado(novas informacoes)</param>

        void AtualizarIdUrl(int id, GeneroDomain genero);

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

        GeneroDomain BuscarPorId(int id);
    }
}
