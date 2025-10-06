using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Infraestrutura.Dominio
{
    public class UsuarioDominio
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public string UsuarioAtualizacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }

        protected UsuarioDominio() { }
        public UsuarioDominio(string usuario, string senha, string email)
        {
            Usuario = usuario;
            Senha = senha;
            Email = email;
        }
    }

    
}