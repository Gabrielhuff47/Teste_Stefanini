using Api.Infraestrutura.Dominio;
using Api.Model;

namespace Api.Infraestrutura.Interfaces;

public interface IPessoaRepositorio
{
    Task<PessoaModel> RegistrarPessoa(PessoaModel pessoa);
    Task<PessoaDominio?> ObterPessoaPorCpf(string cpf);
    Task<PessoaDominio> ObterPessoaPorId(int idPessoa);
    Task<PessoaDominio> AtualizarPessoaPorId(PessoaDominio model);
    Task DeletarPessoaPorId(int idPessoa);
    Task<IEnumerable<PessoaModel>> BuscarPessoas();
}
