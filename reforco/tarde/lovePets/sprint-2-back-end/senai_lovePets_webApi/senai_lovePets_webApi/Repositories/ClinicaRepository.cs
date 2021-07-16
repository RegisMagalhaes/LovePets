using senai_lovePets_webApi.Context;
using senai_lovePets_webApi.Domains;
using senai_lovePets_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Repositories
{
    public class ClinicaRepository : IClinicaRepository
    {
        /// <summary>
        /// Instancia o objeto ctx com a classe lovePetsContext
        /// </summary>
        

        lovePetsContext ctx = new lovePetsContext();



        /// <summary>
        /// Atualiza uma clínica existente
        /// </summary>
        /// <param name="idClinica">Id da clinica que será atualizada</param>
        /// <param name="clinicaAtualizada">Objeto com as novas informações</param>
        public void Atualizar(int idClinica, Clinica clinicaAtualizada)
        {
            Clinica clinicaBuscada = BuscarPorId(idClinica);

            if (clinicaAtualizada.IdClinica>0)
            {
                clinicaBuscada.IdClinica = clinicaAtualizada.IdClinica;
            }

            if (clinicaAtualizada.Endereco!=null)
            {
                clinicaBuscada.Endereco = clinicaAtualizada.Endereco;
            }

            if (clinicaAtualizada.Cnpj!=null)
            {
                clinicaBuscada.Cnpj = clinicaAtualizada.Cnpj;

            }

            if (clinicaAtualizada.RazaoSocial!=null)
            {
                clinicaBuscada.RazaoSocial = clinicaAtualizada.RazaoSocial;
            }
        }

        /// <summary>
        /// Busca uma clínica através do seu ID
        /// </summary>
        /// <param name="idClinica">ID da clinica que será buscada</param>
        /// <returns>clínica encontrada</returns>
        public Clinica BuscarPorId(int idClinica)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Cadastra uma nova clínica
        /// </summary>
        /// <param name="novaClinica"></param>
        public void Cadastrar(Clinica novaClinica)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Deleta uma clínica existente
        /// </summary>
        /// <param name="idClinica">Id da clinica que será deletada</param>
        public void Deletar(int idClinica)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Lista todas as clínicas
        /// </summary>
        /// <returns>Uma lista de clínicas</returns>
        public List<Clinica> ListarTodos()
        {

           
            throw new NotImplementedException();
        }
    }
}
