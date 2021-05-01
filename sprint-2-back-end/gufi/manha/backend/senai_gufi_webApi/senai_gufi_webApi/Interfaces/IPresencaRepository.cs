using senai_gufi_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_gufi_webApi.Interfaces
{
    interface IPresencaRepository
    {
        /// <summary>
        /// Lista todos os eventos que um determinado usuário participa
        /// </summary>
        /// <param name="id">ID do usuário que participa dos eventos listados</param>
        /// <returns>Uma lista de presenças com os dados dos eventos</returns>
        List<Presenca> ListarMinhas(int id);

        /// <summary>
        /// Cria uma nova presença
        /// </summary>
        /// <param name="inscricao">Objeto com as informações da inscrição</param>
        void Inscrever(Presenca inscricao);

        /// <summary>
        /// Altera o status de uma presença
        /// </summary>
        /// <param name="id">ID da presença que terá a situação alterada</param>
        /// <param name="status">Parâmetro que atualiza a situação da presença para Confirmada, Não confirmada ou Recusada</param>
        void AprovarRecusar(int id, string status);
    }
}
