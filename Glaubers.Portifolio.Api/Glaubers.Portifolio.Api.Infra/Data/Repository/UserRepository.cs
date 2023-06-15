using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Repository.Services;
using Glaubers.Portifolio.Api.Domain.Interfaces.Repository;

namespace Glaubers.Portifolio.Api.Infra.Data.Repository
{
    public class UserRepository<T> : Repository<User>, IUserRepository where T : DbContext
    {
        public UserRepository(T context) : base(context) { }
    }
}
