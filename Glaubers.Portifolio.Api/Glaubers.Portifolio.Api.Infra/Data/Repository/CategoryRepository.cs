using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Repository.Services;
using Glaubers.Portifolio.Api.Domain.Interfaces.Repository;

namespace Glaubers.Portifolio.Api.Infra.Data.Repository
{
    public class CategoryRepository<T> : Repository<Category>, ICategoryRepository where T : DbContext
    {
        public CategoryRepository(T context) : base(context) { }
    }
}
