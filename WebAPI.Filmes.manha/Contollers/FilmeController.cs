using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;
using WebAPI.Filmes.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Filmes.manha.Contollers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class FilmeController : ControllerBase
    {

        private IFilmeRepository _filmeRepository { get; set; }

        public FilmeController()
        {
            _filmeRepository= new FilmeRepository();
        }

        /// <summary>
        /// Endpoint que aciona um metodo para cadastro de filmes
        /// </summary>
        /// <param name="novoFilme">Filme que sera cadastrado</param>
        /// <returns>Retorna status code 201</returns>

        [HttpPost]

        public IActionResult Post(FilmeDomain novoFilme)
        {
            try
            {
                _filmeRepository.Cadastrar(novoFilme);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona um metodo de listagem de filmes
        /// </summary>
        /// <returns>Retorna status code 200 com o lista de filmes</returns>

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<FilmeDomain> ListarFilme = _filmeRepository.ListarTodos();

                return Ok(ListarFilme);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o metodo de deletar filmes
        /// </summary>
        /// <param name="id">Id do filme que sera deletado</param>
        /// <returns>Retorna status code 200 com uma mensagem</returns>

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                if(filmeEncontrado == null)
                {
                    return StatusCode(404);
                }
                else
                {
                    _filmeRepository.Deletar(id);

                    return Ok("Filme deletado");
                }             
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona um metodo que busca um filme por seu Id
        /// </summary>
        /// <param name="id">Id que sera usado para encontrar o objeto</param>
        /// <returns>Retorna um StatusCode 200 com o Filme que foi encontrado</returns>

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                if(filmeEncontrado == null)
                {
                    return StatusCode(404);
                }

                else
                {
                    return Ok(filmeEncontrado);
                }
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que atualiza um filme pelo seu corpo(json)
        /// </summary>
        /// <param name="filme">Objeto filme que sera colocado no lugar do antigo filme</param>
        /// <returns>Retorna um StatusCode 200 com uma mensagem</returns>

        [HttpPut]

        public IActionResult AtualizarIdCorpo(FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(filme.IdFilme);

                if(filmeEncontrado == null)
                {
                    return StatusCode(404);
                }

                _filmeRepository.AtualizarIdCorpo(filme);

                return StatusCode(200, "Filme atualizado");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que atualiza um filme passando seu id pea Url
        /// </summary>
        /// <param name="id">Id do filme que sera atualizado</param>
        /// <param name="filme">Objeto do filme que sera atualizado</param>
        /// <returns>Retorna StatusCode 200 com uma mensagem</returns>

        [HttpPut("{id}")]

        public IActionResult AtualizarIdUrl(int id, FilmeDomain filme)
        {
            try
            {
                FilmeDomain filmeEncontrado = _filmeRepository.BuscarPorId(id);

                if (filmeEncontrado == null)
                {
                    return StatusCode(404);
                }

                _filmeRepository.AtualizarIdUrl(id, filme);

                return StatusCode(200, "Filme atualizado");
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
