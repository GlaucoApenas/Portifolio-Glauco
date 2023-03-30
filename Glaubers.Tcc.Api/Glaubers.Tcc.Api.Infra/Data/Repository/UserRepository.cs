using Microsoft.EntityFrameworkCore;
using Glaubers.Tcc.Api.Domain.Models;
using Glaubers.Tcc.Api.Repository.Services;
using Glaubers.Tcc.Api.Domain.Interfaces.Repository;

namespace Glaubers.Tcc.Api.Infra.Data.Repository
{
    public class UserRepository<T> : Repository<User>, IUserRepository where T : DbContext
    {
        public UserRepository(T context) : base(context) { }
    }
}
