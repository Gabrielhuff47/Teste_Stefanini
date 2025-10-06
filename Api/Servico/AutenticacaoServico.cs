using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Infraestrutura.Dominio;
using Api.Infraestrutura.Interfaces;
using Api.Model;

namespace Api.Servico
{
    public class AutenticacaoServico
    {
        private readonly IAutenticacaoRepositorio _autenticacaoRepositorio;
        private readonly TokenServico _tokenServico;
        public AutenticacaoServico(IAutenticacaoRepositorio autenticacaoRepositorio, TokenServico tokenServico)
        {
            _autenticacaoRepositorio = autenticacaoRepositorio;
            _tokenServico = tokenServico;
        }

        public async Task<string> AutenticarUsuario(usuarioModel request)
        {
            var usuario = await _autenticacaoRepositorio.AutenticarUsuario(request.Usuario, request.Senha);

            if (usuario == null)
            {
                throw new InvalidOperationException("Login inválido");
            }

            var token = _tokenServico.GenerateToken(request);
            return token;
        }
    }
}