using Api.Infraestrutura.Dominio;
using Api.Model;

namespace Api.Servico.ConverterPara;

public static class PessoaDominioParaModel
{
    public static PessoaModel Convert(this PessoaDominio pessoaDominio)
    {
        return new PessoaModel
        {
            IdPessoa = pessoaDominio.IdPessoa,
            Nome = pessoaDominio.Nome,
            Cpf = pessoaDominio.Cpf,
            DataNascimento = pessoaDominio.DataNascimento,
            Sexo = pessoaDominio.Sexo,
            Email = pessoaDominio.Email,
            Naturalidade = pessoaDominio.Naturalidade,
            Nacionalidade = pessoaDominio.Nacionalidade,
        };
    }
}
