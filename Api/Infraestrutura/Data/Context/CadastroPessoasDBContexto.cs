using Api.Infraestrutura.Dominio;
using Microsoft.EntityFrameworkCore;

namespace Api.Infraestrutura.Data.Context;

public class CadastroPessoasDBContexto : DbContext
{
    public CadastroPessoasDBContexto(DbContextOptions<CadastroPessoasDBContexto> options) : base(options)
    { }

    public DbSet<PessoaDominio> Pessoas { get; set; }
    public DbSet<UsuarioDominio> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(PessoaMap).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
