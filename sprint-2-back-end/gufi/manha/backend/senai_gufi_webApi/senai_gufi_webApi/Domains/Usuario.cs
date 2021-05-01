using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace senai_gufi_webApi.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Presencas = new HashSet<Presenca>();
        }

        public int IdUsuario { get; set; }
        public int? IdTipoUsuario { get; set; }
        public string NomeUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail deve ser preenchido para cadastrar um usuário!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo senha deve ser preenchido para cadastrar um usuário!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Ao cadastrar um usuário, a senha deverá ter de 5 a 50 caracteres!")]
        public string Senha { get; set; }

        public virtual TiposUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Presenca> Presencas { get; set; }
    }
}
