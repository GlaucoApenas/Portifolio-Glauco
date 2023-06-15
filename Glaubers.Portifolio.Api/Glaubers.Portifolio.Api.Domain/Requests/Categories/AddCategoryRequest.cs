using MediatR;
using Glaubers.Portifolio.Api.Domain.Models;

namespace Glaubers.Portifolio.Api.Domain.Requests.Categories
{
    public class AddCategoryRequest : IRequest<Category>
    {
        public Category Category { get; set; }
    }
}
