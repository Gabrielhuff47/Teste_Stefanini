using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Infraestrutura.Data.Context;
using Api.Infraestrutura.Dominio;
using Api.Infraestrutura.Interfaces;
using Api.Model;
using Microsoft.EntityFrameworkCore;

namespace Api.Infraestrutura.Repositorio
{
    public class AutenticacaoRepositorio : IAutenticacaoRepositorio
    {
        private readonly CadastroPessoasDBContexto _contexto;

        public AutenticacaoRepositorio(CadastroPessoasDBContexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<UsuarioDominio?> AutenticarUsuario(string usuario, string senha)
        {
            return await _contexto.Usuarios
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Usuario == usuario && u.Senha == senha);
        } 
    }
}