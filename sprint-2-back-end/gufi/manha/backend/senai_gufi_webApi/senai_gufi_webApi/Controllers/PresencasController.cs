using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using senai_gufi_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints referentes às Presenças
    /// </summary>

    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // http://localhost:5000/api/presencas
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class PresencasController : ControllerBase
    {
        /// <summary>
        /// Cria um objeto _presencaRepository que irá receber todos os métodos definidos na interfaces
        /// </summary>
        private IPresencaRepository _presencaRepository { get; set; }

        /// <summary>
        /// Instancia este objeto para que haja a referência aos métodos do repositório
        /// </summary>
        public PresencasController()
        {
            _presencaRepository = new PresencaRepository();
        }

        /// <summary>
        /// Lista todas as presenças de um determinado usuário
        /// </summary>
        /// <returns>Uma lista de presenças e um status code 200 0 Ok</returns>
        [HttpGet("minhas")]
        public IActionResult GetMy()
        {
            try
            {
                // Cria uma variável idUsuario que recebe o valor do ID deste usuário que está logado
                int idUsuario = Convert.ToInt32( HttpContext.User.Claims.First( c => c.Type == JwtRegisteredClaimNames.Jti ).Value );

                // Retorna a resposta da requisição 200 - Ok fazendo a chamada para o método e trazendo a lista de presenças
                return Ok(_presencaRepository.ListarMinhas(idUsuario));
            }
            catch (Exception ex)
            {
                return BadRequest(new { 
                    mensagem = "Não é possível mostrar as presenças se o usuário não estiver logado!",
                    ex
                });
            }
        }

        [HttpPost("inscricao/{idEvento}")]
        public IActionResult Join(int idEvento)
        {
            try
            {
                Presenca inscricao = new Presenca()
                {
                    // Armazena na propriedade IdUsuario da presenca criada o ID do usuário logado
                    IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value),
                    
                    // Armazena na propriedade IdEvento o ID do evento que foi recebido na URL da requisição
                    IdEvento = idEvento,

                    // Define a situação da presença como "Não confirmada"
                    Situacao = "Não confirmada"
                };

                _presencaRepository.Inscrever(inscricao);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    mensagem = "Não é possível se inscrever se o usuário não estiver logado!",
                    ex
                });
            }
        }

        [Authorize(Roles = "1")]
        [HttpPatch("{id}")]
        public IActionResult PatchSituation(int id, Presenca status)
        {
            try
            {
                _presencaRepository.AprovarRecusar(id, status.Situacao);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
