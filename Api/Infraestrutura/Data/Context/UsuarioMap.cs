using Api.Infraestrutura.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Infraestrutura.Data.Context
{
public class UsuarioMap : IEntityTypeConfiguration<UsuarioDominio>
{
    public void Configure(EntityTypeBuilder<UsuarioDominio> builder)
    {
        builder.ToTable("USUARIOS");

        builder.HasKey(usuario => usuario.IdUsuario);

        builder.Property(usuario => usuario.Usuario).IsRequired().HasMaxLength(20);
        builder.Property(usuario => usuario.Senha).IsRequired().HasMaxLength(20);
        builder.Property(usuario => usuario.Email).HasMaxLength(100);


        builder.Property(usuario => usuario.UsuarioAtualizacao).HasDefaultValue("SISTEMA");
        builder.Property(usuario => usuario.DataAtualizacao).HasDefaultValueSql("GETDATE()");
        builder.Property(usuario => usuario.DataCriacao).HasDefaultValueSql("GETDATE()");
    }
}
}