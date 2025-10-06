using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Infraestrutura.Dominio;
using Api.Model;

namespace Api.Infraestrutura.Interfaces
{
    public interface IAutenticacaoRepositorio
    {
        Task<UsuarioDominio?> AutenticarUsuario(string usuario, string senha);
    }
}