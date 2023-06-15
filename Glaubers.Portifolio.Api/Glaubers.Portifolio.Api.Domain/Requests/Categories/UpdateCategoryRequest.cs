using MediatR;
using Glaubers.Portifolio.Api.Domain.Models;

namespace Glaubers.Portifolio.Api.Domain.Requests.Categories
{
    public class UpdateCategoryRequest : IRequest<Category>
    {
        public Category Category { get; set; }
    }
}
