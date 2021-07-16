using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IDonoRepository
    {
        /// <summary>
        /// Lista todos os donos
        /// </summary>
        /// <returns>Uma lista de donos</returns>
        List<Dono> ListarTodos();
        /// <summary>
        /// Busca um dono através do seu ID
        /// </summary>
        /// <param name="idDono"></param>
        /// <returns></returns>
        Dono BuscarPorId(int idDono);

        /// <summary>
        /// Cadastra um novo Dono de Pets
        /// </summary>
        /// <param name="novoDono">Objeto com as novas informações</param>
        void Cadastrar(Dono novoDono);

        /// <summary>
        /// Atualiza um dono existente
        /// </summary>
        /// <param name="idDono">id do dono que será atualizado</param>
        /// <param name="donoAtualizado">novas informações do dono</param>
        void Atualizar(int idDono, Dono donoAtualizado);

        /// <summary>
        /// Deleta o dono através do seu id
        /// </summary>
        /// <param name="idDono">id do dono que será deletado</param>
        void Deletar(int idDono);

    }
}
