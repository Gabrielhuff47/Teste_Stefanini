namespace Api.Model;

public class PessoaModel
{
     public int IdPessoa { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public DateTime DataNascimento { get; set; }
    public string? Sexo { get; set; }
    public string? Email { get; set; }
    public string? Naturalidade { get; set; }
    public string? Nacionalidade { get; set; }

    public PessoaModel(int idPessoa, string nome, string cpf, DateTime dataNascimento, string? sexo, string? email, string? naturalidade, string? nacionalidade)
    {
        IdPessoa = idPessoa;
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Sexo = sexo;
        Email = email;
        Naturalidade = naturalidade;
        Nacionalidade = nacionalidade;
    }
    public PessoaModel() { }
}