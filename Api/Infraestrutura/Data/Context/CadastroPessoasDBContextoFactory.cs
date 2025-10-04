using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Infraestrutura.Data.Context;

public class CadastroPessoasDBContextoFactory : IDesignTimeDbContextFactory<CadastroPessoasDBContexto>
{
       public CadastroPessoasDBContexto CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Development.json")
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var builder = new DbContextOptionsBuilder<CadastroPessoasDBContexto>();
        builder.UseSqlServer(connectionString);

        return new CadastroPessoasDBContexto(builder.Options);
    }
}
