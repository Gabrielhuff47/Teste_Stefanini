using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Infraestrutura.Dominio;
using Api.Infraestrutura.Interfaces;
using Api.Model;
using Api.Servico;
using Moq;
using Xunit;

namespace Api.Tests.Servico
{
    public class PessoaServicoTeste
    {
        private readonly Mock<IPessoaRepositorio> _repositorioMock;
        private readonly PessoaServico _pessoaServico;

        public PessoaServicoTeste()
        {
            _repositorioMock = new Mock<IPessoaRepositorio>();
            _pessoaServico = new PessoaServico(_repositorioMock.Object);
        }

        [Fact]
        public async Task RegistrarPessoa_DeveRetonarErro()
        {
            PessoaModel request = new PessoaModel()
            {
                Nome = "Gabriel",
                Cpf = "03979298035",
                DataNascimento = new DateTime(2026, 09, 21)
            };

            var ex = await Assert.ThrowsAsync<InvalidOperationException>(
                () => _pessoaServico.RegistrarPessoa(request)
            );

            Assert.Equal("A Data de Nascimento não pode ser futura.", ex.Message);
        }

        [Fact]
        public async Task RegistrarPessoa_DeveRetonar()
        {
            PessoaModel request = new PessoaModel()
            {
                Nome = "Gabriel",
                Cpf = "03979298035",
                DataNascimento = new DateTime(1999, 09, 02),
                Sexo = "Masculino"
            };
            _repositorioMock
                .Setup(repo => repo.RegistrarPessoa(It.IsAny<PessoaModel>()))

          .ReturnsAsync(request);

            var result = await _pessoaServico.RegistrarPessoa(request);

            Assert.NotNull(result);
        }


        [Fact]
        public async Task BuscarPessoas_DeveRetornarListaDePessoas_QuandoExistiremPessoas()
        {
            var listaEsperada = new List<PessoaModel>
            {
                new PessoaModel {  Nome = "Gabriel", Cpf = "12345678900", Sexo = "Masculino", DataNascimento = new DateTime(1999, 9, 2)},
                new PessoaModel {  Nome = "Ana", Cpf = "98765432100", Sexo = "Feminino", DataNascimento = new DateTime(2000, 5, 10) }
            };

            _repositorioMock
                .Setup(repo => repo.BuscarPessoas())
                .ReturnsAsync(listaEsperada);

            var resultado = await _pessoaServico.BuscarPessoas();

            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal("Gabriel", resultado.First().Nome);
        }


        [Fact]
        public async Task AtualizarPessoaPorId_DeveRetornarPessoaAtualizada_QuandoValido()
        {
            var model = new PessoaDominio
            {
                IdPessoa = 1,
                Nome = "Gabriel",
                Cpf = "12345678900",
                DataNascimento = new DateTime(1999, 9, 2)
            };

            var pessoaExistente = new PessoaDominio
            {
                IdPessoa = 1,
                Nome = "Gabriel Antigo",
                Cpf = "98765432100",
                DataNascimento = new DateTime(1995, 1, 1)
            };

            _repositorioMock
                .Setup(r => r.ObterPessoaPorId(model.IdPessoa))
                .ReturnsAsync(pessoaExistente);

            _repositorioMock
                .Setup(r => r.AtualizarPessoaPorId(It.IsAny<PessoaDominio>()))
                .ReturnsAsync(model);

            var result = await _pessoaServico.AtualizarPessoaPorId(model);

            Assert.NotNull(result);
            Assert.Equal(model.Nome, result.Nome);
            _repositorioMock.Verify(r => r.AtualizarPessoaPorId(It.IsAny<PessoaDominio>()), Times.Once);
        }

        [Fact]
        public async Task AtualizarPessoaPorId_DeveLancarExcecao_QuandoCpfDuplicado()
        {
            var model = new PessoaDominio
            {
                IdPessoa = 1,
                Cpf = "12345678900"
            };

            var pessoaExistente = new PessoaDominio
            {
                IdPessoa = 1,
                Cpf = "12345678900"
            };

            _repositorioMock
                .Setup(r => r.ObterPessoaPorId(model.IdPessoa))
                .ReturnsAsync(pessoaExistente);

            await Assert.ThrowsAsync<InvalidOperationException>(() =>
                _pessoaServico.AtualizarPessoaPorId(model)
            );
        }

        [Fact]
        public async Task DeletarPessoaPorId_DeveExecutarSemErros_QuandoIdValido()
        {
            int idPessoa = 1;

            _repositorioMock
                .Setup(r => r.DeletarPessoaPorId(idPessoa))
                .Returns(Task.CompletedTask);

            await _pessoaServico.DeletarPessoaPorId(idPessoa);

            _repositorioMock.Verify(r => r.DeletarPessoaPorId(idPessoa), Times.Once);
        }

        [Fact]
        public async Task DeletarPessoaPorId_DeveLancarExcecao_QuandoIdInvalido()
        {
            int idPessoa = 0;

            var excecao = await Assert.ThrowsAsync<ArgumentException>(() =>
                _pessoaServico.DeletarPessoaPorId(idPessoa)
            );

            Assert.Equal("Informe um idPessoa valido", excecao.Message);
        }

    }
}
