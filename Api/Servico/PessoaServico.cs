using Api.Infraestrutura.Dominio;
using Api.Infraestrutura.Interfaces;
using Api.Model;

namespace Api.Servico;

public class PessoaServico
{
    private readonly IPessoaRepositorio _repositorio;

    public PessoaServico(IPessoaRepositorio repositorio)
    {
        _repositorio = repositorio;
    }
    public async Task<PessoaModel> RegistrarPessoa(PessoaModel model)
    {
        var cpfExistente = await _repositorio.ObterPessoaPorCpf(model.Cpf);

        if (cpfExistente != null)
            throw new InvalidOperationException("Já existe uma pessoa cadastrada com este CPF.");


        if (model.DataNascimento > DateTime.Now)
            throw new InvalidOperationException("A Data de Nascimento não pode ser futura.");

        model.DataNascimento = model.DataNascimento.Date;
        var novoRegistroPessoa = await _repositorio.RegistrarPessoa(model);

        return novoRegistroPessoa;
    }

    public async Task<PessoaDominio> ObterPessoaPorId(int idPessoa)
    {
        var response = await _repositorio.ObterPessoaPorId(idPessoa);

        return response;
    }

    public async Task<IEnumerable<PessoaModel>> BuscarPessoas()
    {
        var response = await _repositorio.BuscarPessoas();

        return response;
    }

    public async Task<PessoaDominio> AtualizarPessoaPorId(PessoaDominio model)
    {
        var pessoaRegistro = await _repositorio.ObterPessoaPorId(model.IdPessoa);

        model.DataAtualizacao = DateTime.Now;
        model.UsuarioAtualizacao = "usuarioLogado";

        if (pessoaRegistro == null)
            throw new Exception($"Pessoa com ID {model.IdPessoa} não encontrada");

        if (model.Cpf == pessoaRegistro.Cpf)
            throw new InvalidOperationException("Já existe uma pessoa cadastrada com este CPF.");


        if (model.DataNascimento > DateTime.Now)
            throw new InvalidOperationException("A Data de Nascimento não pode ser futura.");

        var pessoaAtualizada = await _repositorio.AtualizarPessoaPorId(model);

        return pessoaAtualizada;

    }

    public async Task DeletarPessoaPorId(int idPessoa)
    {
        if (idPessoa == 0)
        {
            throw new ArgumentException("Informe um idPessoa valido");
        }
        await _repositorio.DeletarPessoaPorId(idPessoa);
    }
}
