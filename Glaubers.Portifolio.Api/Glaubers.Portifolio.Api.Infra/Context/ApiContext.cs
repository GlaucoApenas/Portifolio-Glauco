using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Infra.Data.Mappings;

namespace Glaubers.Portifolio.Api.Infra.Context
{
    public sealed class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            try
            {
                // Verificando o Server
                //Database.OpenConnection();
                //Database.CloseConnection();

                // Checando se o Banco dados já existe
                if (Database.CanConnect())
                    Database.SetCommandTimeout(5000); // Setando tempo de TIMEOUT
                else
                {
                    // Criando a Base caso não encontre o Banco
                    Database.EnsureCreated();
                }
                //Database.EnsureDeleted();   // Caso precise Reiniciar a Base rode o "EnsureDeleted" depois o "EnsureCreated"
            }
            catch (Exception e)
            {
                throw;
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new PostMap());
            builder.ApplyConfiguration(new CategoryMap());
        }
    }
}
