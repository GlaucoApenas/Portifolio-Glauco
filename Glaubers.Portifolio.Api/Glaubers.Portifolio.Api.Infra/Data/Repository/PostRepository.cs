using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Repository.Services;
using Glaubers.Portifolio.Api.Domain.Interfaces.Repository;

namespace Glaubers.Portifolio.Api.Infra.Data.Repository
{
    public class PostRepository<T> : Repository<Post>, IPostRepository where T : DbContext
    {
        public PostRepository(T context) : base(context) { }
    }
}
