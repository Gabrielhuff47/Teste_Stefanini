using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Infraestrutura.Dominio;
using Api.Model;
using Api.Servico;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaServico _pessoaServico;

        public PessoaController(PessoaServico pessoaServico)
        {
            _pessoaServico = pessoaServico;
        }

        [HttpPost("CadastrarPessoa")]
        public async Task<IActionResult> CadastrarPessoa([FromBody] PessoaModel request)
        {

            var pessoa = await _pessoaServico.RegistrarPessoa(request);

            return CreatedAtAction(nameof(ObterPessoaPorId), new { idPessoa = pessoa.IdPessoa }, pessoa);
        }

        [HttpGet("{idPessoa}")]
        public async Task<IActionResult> ObterPessoaPorId(int idPessoa)
        {
            var pessoa = await _pessoaServico.ObterPessoaPorId(idPessoa);
            if (pessoa == null)
                return NotFound();

            return Ok(pessoa);
        }

        [HttpGet("ObterPessoas")]
        public async Task<IEnumerable<PessoaModel>> Get()
        {
            var pessoas = await _pessoaServico.BuscarPessoas();

            return pessoas;
        }

        [HttpPut("AtualizarPessoa")]
        public async Task<IActionResult> AtualizarPessoa([FromBody] PessoaDominio request)
        {
            var pessoaAtualizada = await _pessoaServico.AtualizarPessoaPorId(request);

            return Ok(pessoaAtualizada);
        }

        [HttpDelete("DeletarPessoa/{idPessoa}")]
        public async Task<IActionResult> DeletarPessoaPorId(int idPessoa)
        {
            await _pessoaServico.DeletarPessoaPorId(idPessoa);

            return Ok();
        }
    }
}