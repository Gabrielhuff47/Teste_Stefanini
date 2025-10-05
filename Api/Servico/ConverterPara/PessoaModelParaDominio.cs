using Api.Infraestrutura.Dominio;
using Api.Model;

namespace Api.Servico.ConverterPara;

public static class PessoaModelParaDominio
{
    public static PessoaDominio Convert(this PessoaModel pessoaModel)
    {
        return new PessoaDominio
        {
            IdPessoa = pessoaModel.IdPessoa,
            Nome = pessoaModel.Nome,
            Cpf = pessoaModel.Cpf,
            DataNascimento = pessoaModel.DataNascimento,
            Sexo = pessoaModel.Sexo,
            Email = pessoaModel.Email,
            Naturalidade = pessoaModel.Naturalidade,
            Nacionalidade = pessoaModel.Nacionalidade,
        };
    }
}
