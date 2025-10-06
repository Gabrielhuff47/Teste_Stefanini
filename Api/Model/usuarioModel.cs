using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Model
{
    public class usuarioModel
    {
        [Required(ErrorMessage = "O campo de usuário é obrigatório")]
        public string Usuario { get; set; }
        [Required(ErrorMessage = "O campo de senha é obrigatório")]
        public string Senha { get; set; }
    }
}