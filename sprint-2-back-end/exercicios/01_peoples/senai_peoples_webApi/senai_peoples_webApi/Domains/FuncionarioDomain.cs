using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace senai_peoples_webApi.Domains
{
    /// <summary>
    /// Classe que representa a entidade Funcionarios
    /// </summary>
    public class FuncionarioDomain
    {
        public int IdFuncionario { get; set; }

        [Required(ErrorMessage = "O nome do funcionário é obrigatório!")]
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Informe a data de nascimento do funcionário!")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }
    }
}
