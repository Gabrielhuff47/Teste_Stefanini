using Api.Infraestrutura.Data.Context;
using Api.Infraestrutura.Dominio;
using Api.Infraestrutura.Interfaces;
using Api.Model;
using Api.Servico.ConverterPara;
using Microsoft.EntityFrameworkCore;

namespace Api.Infraestrutura.Repositorio;

public class PessoaRepositorio : IPessoaRepositorio
{
    private readonly CadastroPessoasDBContexto _contexto;

    public PessoaRepositorio(CadastroPessoasDBContexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<PessoaModel> RegistrarPessoa(PessoaModel pessoa)
    {
        var entidade = pessoa.Convert();
        _contexto.Pessoas.Add(entidade);

        await _contexto.SaveChangesAsync();

        return entidade.Convert();
    }

    public async Task<PessoaDominio?> ObterPessoaPorCpf(string cpf)
    {
        return await _contexto.Pessoas
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.Cpf == cpf);
    }

    public async Task<PessoaDominio?> ObterPessoaPorId(int idPessoa)
    {
        return await _contexto.Pessoas
            .AsNoTracking()
            .FirstOrDefaultAsync(p => p.IdPessoa == idPessoa);
    }

    public async Task<IEnumerable<PessoaModel>> BuscarPessoas()
    {
        var listaPessoas = await _contexto.Pessoas
            .AsNoTracking()
            .ToListAsync();

        return listaPessoas.Convert();
    }

    public async Task<PessoaDominio> AtualizarPessoaPorId(PessoaDominio pessoa)
    {
        _contexto.Pessoas.Update(pessoa);

        var entry = _contexto.Entry(pessoa);
        entry.Property("DataCriacao").IsModified = false;

        await _contexto.SaveChangesAsync();

        return pessoa;
    }

    public async Task DeletarPessoaPorId(int idPessoa)
    {
        var pessoa = await _contexto.Pessoas.FindAsync(idPessoa);

        if (pessoa == null)
        {
            return;
        }

        _contexto.Pessoas.Remove(pessoa);

        await _contexto.SaveChangesAsync();
    }
}