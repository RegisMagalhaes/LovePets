using senai_lovePets_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_lovePets_webApi.Interfaces
{
    interface IPetRepostitory
    {
        /// <summary>
        /// Lista todos os Pets
        /// </summary>
        /// <returns>uma lista de Pets</returns>
        List<Pet> ListarTodos();

        /// <summary>
        /// Busca um pet através do seu ID
        /// </summary>
        /// <param name="idPet">id do Pet que será buscado</param>
        /// <returns>o Pet encontrado</returns>
        Pet BuscarPorId(int idPet);

        /// <summary>
        /// Cadastra um novo pet
        /// </summary>
        /// <param name="idPet">id do PET que será cadastrado</param>
        /// <param name="petAtualizado">Objeto com as novas informações</param>
        void Cadastrar(int idPet, Pet petAtualizado);

        /// <summary>
        /// Atualiza um pet existente
        /// </summary>
        /// <param name="idPet">id do Pet que será atualizado</param>
        /// <param name="petAtualizado">Objeto com as novas informações</param>
        void Atualizar(int idPet, Pet petAtualizado);


        /// <summary>
        /// Deleta um Pet através do seu id
        /// </summary>
        /// <param name="idPet">id do Pet que será deletado</param>
        void Deletar(int idPet);

    }
}
