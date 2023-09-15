using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;
using WebAPI.Filmes.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Filmes.manha.Contollers
{
    //Define que a rota de uma requisicao sera no seguinte formato
    //dominio/api/nomeController
    //ex: http://localhost:5000/api/genero
    [Route("api/[controller]")]
    //define que e um controlador de api
    [ApiController]
    //Define a resposta da api como json
    [Produces("application/json")]

    //metodo controlador que herda da controle base
    //Onde seraa criado os endpoints[rotas]
    public class GeneroController : ControllerBase
    {
        /// <summary>
        /// Objeto _generoRepository ira receber todos os metodos definidos da interface IGeneroRepository
        /// </summary>
        private IGeneroRepository _generoRepository { get; set; }
        /// <summary>
        /// instancia o objeto IGeneroRepository para que haja referencia aos metodos no repositorio
        /// </summary>
        public GeneroController()
        {
            _generoRepository = new GeneroRepository();
        }

        /// <summary>
        /// EndPoint que aciona o metodo listar todos no repositorio e retorna a resposta para o usuario(frontend)
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Authorize(Roles = "True, False")]
        public IActionResult Get()
        {
            try
            {
                //Cria lista que recebe os dados da requisicao
                List<GeneroDomain> ListaGeneros = _generoRepository.ListarTodos();
                //retorna a lista no formato json com status code ok
                return Ok(ListaGeneros);
            }
            catch (Exception erro)
            {
                //Retorna um status code erro 400 e a mensagem do erro 
                return BadRequest(erro.Message);
            }

        }

        /// <summary>
        /// Endpoint aciona  metodo de cadastro
        /// </summary>
        /// <param name="novoGenero">objeto recebido</param>
        /// <returns>Status code 201(Created)</returns>

        [HttpPost]
        [Authorize (Roles = "true")]
        public IActionResult Post(GeneroDomain novoGenero)
        {


            try
            {
                _generoRepository.Cadastrar(novoGenero);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Metodo que aciona o Deletar no repositorio e deleta com a Id dada pelo usuario
        /// </summary>
        /// <param name="id">Id do genero a ser deletado</param>
        /// <returns>Retorna Status code 200(OK)</returns>

        [HttpDelete("{id}")]

        public IActionResult Delete(int id)
        {
            try
            {
                _generoRepository.Deletar(id);

                return StatusCode(200);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Busca um genero por um Id
        /// </summary>
        /// <param name="id">Id do genero a ser buscado</param>
        /// <returns>Retorna genero com Id correspondente</returns>

        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {

            try
            {
                GeneroDomain generoEncontrado = _generoRepository.BuscarPorId(id);

                if (generoEncontrado == null)
                {
                    return BadRequest("Genero nao encontrado");
                }

                return Ok(generoEncontrado);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza genero pela url, colocando Id na url e seu nome no json
        /// </summary>
        /// <param name="id">Id do genero a ser atualizado</param>
        /// <param name="genero">Nome do genero a ser atualizado</param>
        /// <returns>Retorna statusCode ok</returns>

        [HttpPut("{id}")]

        public IActionResult AtualizarIdUrl(int id, GeneroDomain genero)
        {
            try
            {
                if(_generoRepository.BuscarPorId(id) == null)
                {
                    return BadRequest("Id nao encontrado");
                }
                else
                {
                    _generoRepository.AtualizarIdUrl(id, genero);
                    return Ok(genero);
                }



            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
            
        }

        /// <summary>
        /// Atualiza o genero pelo seu corpo(Pelo json)
        /// </summary>
        /// <param name="genero">Genero a ser atualizado</param>
        /// <returns>Retorna status ok</returns>

        [HttpPut]

        public IActionResult AtualizarIdCorpo(GeneroDomain genero)
        {
            try
            {
                if (_generoRepository.BuscarPorId(genero.IdGenero) == null)
                {
                    return BadRequest("Id nao encontrado");
                }
                else
                {
                    _generoRepository.AtualizarIdCorpo(genero);
                    return Ok(genero);
                }



            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
