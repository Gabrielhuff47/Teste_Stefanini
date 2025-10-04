using Api.Infraestrutura.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infraestrutura.Data.Context;

public class PessoaMap : IEntityTypeConfiguration<PessoaDominio>
{
    public void Configure(EntityTypeBuilder<PessoaDominio> builder)
    {
        builder.ToTable("PESSOAS");

        builder.HasKey(pessoa => pessoa.IdPessoa);

        builder.Property(pessoa => pessoa.IdPessoa).IsRequired();
        builder.Property(pessoa => pessoa.Nome).IsRequired().HasMaxLength(200);
        builder.Property(pessoa => pessoa.Cpf).IsRequired().HasMaxLength(11);
        builder.HasIndex(pessoa => pessoa.Cpf).IsUnique();
        builder.Property(pessoa => pessoa.Sexo).HasMaxLength(20);
        builder.Property(pessoa => pessoa.Email).HasMaxLength(200);
        builder.Property(pessoa => pessoa.DataNascimento).IsRequired();
        builder.Property(pessoa => pessoa.Naturalidade).HasMaxLength(100);
        builder.Property(pessoa => pessoa.Nacionalidade).HasMaxLength(100);

        builder.Property(pessoa => pessoa.UsuarioAtualizacao).HasDefaultValue("SISTEMA");
        builder.Property(pessoa => pessoa.DataAtualizacao).HasDefaultValueSql("GETDATE()");
        builder.Property(pessoa => pessoa.DataCriacao).HasDefaultValueSql("GETDATE()");
    }
}
