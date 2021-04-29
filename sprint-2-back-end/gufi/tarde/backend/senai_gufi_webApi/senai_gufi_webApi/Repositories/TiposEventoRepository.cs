using senai_gufi_webApi.Contexts;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos tipos de eventos
    /// </summary>
    public class TiposEventoRepository : ITiposEventoRepository
    {
        /// <summary>
        /// Objeto contexto por onde serão chamados os métodos do EF Core
        /// </summary>
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Atualiza um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será atualizado</param>
        /// <param name="tipoEventoAtualizado">Objeto com as novas informações</param>
        public void Atualizar(int id, TiposEvento tipoEventoAtualizado)
        {
            // Busca um tipo de evento através do id
            TiposEvento tipoEventoBuscado = BuscarPorId(id);

            // Verifica se o título do tipo de evento foi informado
            if (tipoEventoAtualizado.TituloTipoEvento != null)
            {
                // Atribui os novos valores aos campos existentes
                tipoEventoBuscado.TituloTipoEvento = tipoEventoAtualizado.TituloTipoEvento;
            }

            // Atualiza o tipo de evento que foi buscado
            ctx.TiposEventos.Update(tipoEventoBuscado);

            // Salva as informações para serevem gravas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Busca um tipo de evento através do ID
        /// </summary>
        /// <param name="id">ID do tipo de evento que será buscado</param>
        /// <returns>Um tipo de evento encontrado</returns>
        public TiposEvento BuscarPorId(int id)
        {
            // Retorna o primeiro tipo de evento para o ID informado
            return ctx.TiposEventos.FirstOrDefault(te => te.IdTipoEvento == id);
        }

        /// <summary>
        /// Cadastra um novo tipo de evento
        /// </summary>
        /// <param name="novoTipoEvento">Objeto com as informações que serão cadastradas</param>
        public void Cadastrar(TiposEvento novoTipoEvento)
        {
            // Adiciona este novoTipoEvento
            ctx.TiposEventos.Add(novoTipoEvento);

            // Salva as informações para serem gravadas no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um tipo de evento existente
        /// </summary>
        /// <param name="id">ID do tipo de evento que será deletado</param>
        public void Deletar(int id)
        {
            // Remove o tipo de evento que foi buscado
            ctx.TiposEventos.Remove(BuscarPorId(id));

            // Salva as alterações
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os tipos de eventos
        /// </summary>
        /// <returns>Uma lista de tipos de eventos</returns>
        public List<TiposEvento> ListarTodos()
        {
            // Retorna uma lista com todas as informações dos tipos de eventos
            return ctx.TiposEventos.ToList();
        }
    }
}
