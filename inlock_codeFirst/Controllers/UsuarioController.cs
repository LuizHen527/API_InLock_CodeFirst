using inlock_codeFirst.Domains;
using inlock_codeFirst.Interface;
using inlock_codeFirst.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inlock_codeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Post(UsuarioDomain usuario)
        {
            try
            {
                _usuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
