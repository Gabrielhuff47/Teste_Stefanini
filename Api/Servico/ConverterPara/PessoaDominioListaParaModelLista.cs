using Api.Infraestrutura.Dominio;
using Api.Model;

namespace Api.Servico.ConverterPara;

public static class PessoaDominioListaParaModelLista
{
    public static IEnumerable<PessoaModel> Convert(this IEnumerable<PessoaDominio> pessoas)
    {
        return pessoas.Select(pessoa => pessoa.Convert());
    }
}
