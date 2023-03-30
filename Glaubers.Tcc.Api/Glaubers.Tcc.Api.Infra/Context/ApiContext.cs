using Microsoft.EntityFrameworkCore;
using Glaubers.Tcc.Api.Infra.Data.Mappings;

namespace Glaubers.Tcc.Api.Infra.Context
{
    public sealed class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options) : base(options)
        {
            Database.SetCommandTimeout(5000);

            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserMap());
        }
    }
}
