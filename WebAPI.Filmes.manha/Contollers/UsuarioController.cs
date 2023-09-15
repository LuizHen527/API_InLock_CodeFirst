using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI.Filmes.manha.Domains;
using WebAPI.Filmes.manha.Interfaces;
using WebAPI.Filmes.manha.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebAPI.Filmes.manha.Contollers
{

    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository= new UsuarioRepository();
        }

        /// <summary>
        /// Endpoint que Compara a senha e email digitada pelo usuario com as mesmas que estao no banco de dados.
        /// </summary>
        /// <param name="Email">Email que sera validado</param>
        /// <param name="Senha">Senha que sera validada</param>
        /// <returns>Retorna StatusCode 200 com o Usuario encontrado</returns>

        [HttpPost]

        public IActionResult Login(UsuarioDomain user)
        {
            try
            {
                UsuarioDomain usuario = _usuarioRepository.Login(user.Email, user.Senha);

                if (usuario == null)
                {
                    return StatusCode(404);
                }

                //Caso encontre prossegue para a criacao do token

                //Parte 1: Definir informacoes(Claims) que serao fornecidas no token(Payload)

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, usuario.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Permissao.ToString()),

                    //Existe a possibilidade de criar uma claim personalizada

                    new Claim("Claim personalizada", "Valor da Claim personalizada")
                };

                //Parte 2: Definir chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("Filmes-chave-autenticacao-webapi-dev"));

                //Parte 3: Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                //Parte 4: Gerar token

                var token = new JwtSecurityToken
                (
                    //emissor do token 
                    issuer: "WebAPI.Filmes.manha",

                    //Destinatario do token
                    audience: "WebAPI.Filmes.manha",

                    //Dados definidos nas claims(informacoes)
                    claims: claims,

                    //Tempo de expiracao
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );

            //Parte 5: Retornar um token 

            return Ok(new {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            }) ;
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    }
}
