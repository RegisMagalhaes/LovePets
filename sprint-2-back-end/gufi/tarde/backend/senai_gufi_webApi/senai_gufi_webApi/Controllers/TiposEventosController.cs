using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using senai_gufi_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Controller responsável pelos endpoints (URLs) referentes aos tipos de eventos
/// </summary>
namespace senai_gufi_webApi.Controllers
{
    // Define que o tipo de resposta da API será no formato JSON
    [Produces("application/json")]

    // Define que a rota de uma requisição será no formato dominio/api/nomeController
    // ex: http://localhost:5000/api/tiposeventos
    [Route("api/[controller]")]

    // Define que é um controlador de API
    [ApiController]
    public class TiposEventosController : ControllerBase
    {
        /// <summary>
        /// Objeto que irá receber os métodos definidos na interface ITiposEventoRepository
        /// </summary>
        private ITiposEventoRepository _tiposEventoRepository { get; set; }

        /// <summary>
        /// Instancia o objeto _tiposEventoRepository para que haja a referência aos métodos do repositório
        /// </summary>
        public TiposEventosController()
        {
            _tiposEventoRepository = new TiposEventoRepository();
        }

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Uma lista de tipos de eventos e um status code 200 - Ok</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposEventoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                // Retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Busca um tipo de evento através do id
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento buscadoe um status code 200 - Ok</returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                // Retorna a resposta da requisição fazendo a chamada para o método
                return Ok(_tiposEventoRepository.BuscarPorId(id));
            }
            catch (Exception ex)
            {
                // Retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto que será cadastrado</param>
        /// <returns>Um status code 201 - Created</returns>
        [HttpPost]
        public IActionResult Post(TiposEvento novoTipoEvento)
        {
            try
            {
                // Faz a chamada para o método
                _tiposEventoRepository.Cadastrar(novoTipoEvento);

                // Retorna um status code
                return StatusCode(201);
            }
            catch (Exception ex)
            {
                // Retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpPut("{id}")]
        public IActionResult Put(int id, TiposEvento tipoEventoAtualizado)
        {
            try
            {
                // Faz a chamada para o método
                _tiposEventoRepository.Atualizar(id, tipoEventoAtualizado);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // Retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Deleta um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        /// <returns>Um status code 204 - No Content</returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                // Faz a chamada para o método
                _tiposEventoRepository.Deletar(id);

                // Retorna um status code
                return StatusCode(204);
            }
            catch (Exception ex)
            {
                // Retorna um status code 400 - BadRequest com o código da exception
                return BadRequest(ex);
            }
        }
    }
}
