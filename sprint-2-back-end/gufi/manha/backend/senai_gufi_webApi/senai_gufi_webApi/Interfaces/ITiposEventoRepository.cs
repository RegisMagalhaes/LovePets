using senai_gufi_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório TiposEventoRepository
    /// </summary>
    interface ITiposEventoRepository
    {
        // Definição de métodos, seguem a estrutura:
        // tipoRetorno nomeMetodo(tipoParametro nomeParametro);

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Uma lista de tipos de eventos</returns>
        List<TiposEvento> ListarTodos();

        /// <summary>
        /// Busca um tipo de evento através do seu ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento encontrado</returns>
        TiposEvento BuscarPorId(int id);

        /// <summary>
        /// Cadastra um tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto novoTipoEvento que será cadastrado</param>
        void Cadastrar(TiposEvento novoTipoEvento);

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto tipoEventoAtualizado com as novas informações</param>
        void Atualizar(int id, TiposEvento tipoEventoAtualizado);

        /// <summary>
        /// Deleta um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        void Deletar(int id);
    }
}
