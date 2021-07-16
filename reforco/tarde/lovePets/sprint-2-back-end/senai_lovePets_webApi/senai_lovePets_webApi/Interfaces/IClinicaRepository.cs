using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IClinicaRepository
    {

        /// <summary>
        /// Lista todas as clínicas
        /// </summary>
        /// <returns>Uma lista de clínicas</returns>
        List<Clinica> ListarTodos();


        /// <summary>
        /// Busca uma clínica através do seu ID
        /// </summary>
        /// <param name="idClinica">ID da clinica que será buscada</param>
        /// <returns>clínica encontrada</returns>
        Clinica BuscarPorId(int idClinica);


        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica"></param>
        void Cadastrar(Clinica novaClinica);


        /// <summary>
        /// Atualiza uma clínica existente
        /// </summary>
        /// <param name="idClinica">Id da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        void Atualizar(int idClinica, Clinica clinicaAtualizada);

        /// <summary>
        /// Deleta uma clínica existente
        /// </summary>
        /// <param name="idClinica">Id da clinica que será deletada</param>
        void Deletar(int idClinica);

      

    }
}
