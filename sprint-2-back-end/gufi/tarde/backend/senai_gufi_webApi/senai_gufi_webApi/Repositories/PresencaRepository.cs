using Microsoft.EntityFrameworkCore;
using senai_gufi_webApi.Contexts;
using senai_gufi_webApi.Domains;
using senai_gufi_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Repositories
{
    public class PresencaRepository : IPresencaRepository
    {
        GufiContext ctx = new GufiContext();

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá sua situação alterada</param>
        /// <param name="status">Parâmetro que atualiza a situação da presença para 0 - Recusada, 1 - Confirmada, 2 - Não confirmada</param>
        public void AprovarRecusar(int id, string status)
        {
            Presenca presencaBuscada = ctx.Presencas
                .Include(p => p.IdUsuarioNavigation)
                .Include(p => p.IdEventoNavigation)
                .FirstOrDefault(p => p.IdPresenca == id);

            switch (status)
            {
                case "0":
                    presencaBuscada.Situacao = "Recusada";
                    break;

                case "1":
                    presencaBuscada.Situacao = "Confirmada";
                    break;

                case "2":
                    presencaBuscada.Situacao = "Não confirmada";
                    break;

                default:
                    presencaBuscada.Situacao = presencaBuscada.Situacao;
                    break;
            }

            ctx.Presencas.Update(presencaBuscada);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        public void Inscrever(Presenca inscricao)
        {
            // Outra forma, caso os dados da inscrição (nova presença) sejam enviados pelo usuário
            // independente do status que o usuário tente cadastrar ao se inscrever
            // por padrão, a situação será sempre "Não confirmada"
            // inscricao.Situacao = "Não confirmada";

            // Adiciona uma nova presença
            ctx.Presencas.Add(inscricao);

            // Salva as informações no banco de dados
            ctx.SaveChanges();
        }

        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        public List<Presenca> ListarMinhas(int id)
        {
            // Retorna uma lista com todas as informações das presenças
            return ctx.Presencas
                // Adiciona na busca as informações dos eventos que o usuário participa
                .Include(p => p.IdEventoNavigation)
                // Adiciona na busca as informações dos tipos dos eventos que o usuário participa
                .Include(p => p.IdEventoNavigation.IdTipoEventoNavigation)
                // Adiciona na busca as informações das instituições onde os eventos acontecem
                .Include(p => p.IdEventoNavigation.IdInstituicaoNavigation)
                // Estabelece como parâmetro de consulta o ID do usuário recebido
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}
