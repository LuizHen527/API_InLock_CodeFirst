using inlock_codeFirst.Interface;
using inlock_codeFirst.Repositories;
using inlock_codeFirst.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace inlock_codeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]

        public IActionResult Login(LoginViewModel usuario)
        {

        }
    }
}
