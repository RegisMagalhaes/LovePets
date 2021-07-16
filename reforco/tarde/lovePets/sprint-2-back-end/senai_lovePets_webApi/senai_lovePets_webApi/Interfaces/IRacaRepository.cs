using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IRacaRepository
    {
        /// <summary>
        /// Lista todas as raças
        /// </summary>
        /// <returns>uma lista com todas as raças dos pets</returns>
        List<Raca> ListarTodos();

        /// <summary>
        /// Busca uma raça através do seu id
        /// </summary>
        /// <param name="idRaca">id da raça que será buscada</param>
        /// <returns>uma raça encontrada pelo sistema</returns>
        Raca BuscarPorId(int idRaca);

        /// <summary>
        /// Cadastra uma nova Raça
        /// </summary>
        /// <param name="novaRaca">id da raça que será cadastrada</param>
        void Cadastrar(Raca novaRaca);

        /// <summary>
        /// Atualiza uma raça existente
        /// </summary>
        /// <param name="idRaca">id da Raça que será cadastrada</param>
        /// <param name="racaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int idRaca, Raca racaAtualizada);


        /// <summary>
        /// Deleta uma Raça
        /// </summary>
        /// <param name="idRaca">id da Raça que será deletada</param>
        void Deletar(int idRaca);



    }
}
