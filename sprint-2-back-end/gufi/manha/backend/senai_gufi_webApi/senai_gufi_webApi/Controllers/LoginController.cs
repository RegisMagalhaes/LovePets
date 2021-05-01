using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using senai_gufi_webApi.Repositories;
using senai_gufi_webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes ao Login
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // http://localhost:5000/api/login
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class LoginController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _usuarioRepository que irá receber todos os métodos definidos na interfaces
        /// </summary>
        private IUsuarioRepository _usuarioRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos do repositório
        /// </summary>
        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Valida o usuário
        /// </summary>
        /// <param name="login">Objeto que contém o e-mail e a senha do usuário</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                // Busca um usuário pelo e-mail e senha
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Email, login.Senha);

                // Caso não encontre um usuário com o e-mail e a senha informados
                if (usuarioBuscado == null)
                {
                    // Retorna NotFound com uma mensagem persnalizada
                    return NotFound("E-mail ou senha inválidos!");
                }

                // Caso o usuário seja encontrado, prossegue para a criação do token

                /*
                    Dependências

                    Criar e validar o JWT:          System.IdentityModel.Tokens.Jwt
                    Integrar a autenticação:        Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o SDK .NET                 
                */

                // Define os dados que serão fornecidos no token - Payload
                var claims = new[]
                {
                    // Armazena na Claim o e-mail do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),

                    // Armazena na Claim o ID do usuário autenticado
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),

                    // Outra forma, armazenado o título do tipo de usuário. Ex: Administrador
                    // new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuarioNavigation.TituloTipoUsuario)

                    // Armazena na Claim o id do tipo de usuário que foi autenticado. Ex: 1
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString())
                };

                // Define a chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("gufi-chave-autenticacao"));

                // Define as credenciais do token
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var dadosToken = new JwtSecurityToken(
                        issuer:                 "gufi.webApi",                  // emissor do token
                        audience:               "gufi.webApi",                  // destinatário do token
                        claims:                 claims,                         // dados definidos acima (linha 75)
                        expires:                DateTime.Now.AddMinutes(30),    // tempo de expiração
                        signingCredentials:     creds                           // credenciais do token
                    );

                // Retorna 200 - Ok com o token gerado
                return Ok(new { 
                    token = new JwtSecurityTokenHandler().WriteToken(dadosToken)
                });

            }
            catch (Exception ex)
            {
                // caso aconteça algum erro, retorna o código da exception
                return BadRequest(ex);
            }
        }
    }
}
