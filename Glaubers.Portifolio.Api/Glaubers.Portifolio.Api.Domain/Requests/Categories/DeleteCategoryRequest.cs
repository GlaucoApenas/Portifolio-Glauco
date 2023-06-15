using MediatR;

namespace Glaubers.Portifolio.Api.Domain.Requests.Categories
{
    public class DeleteCategoryRequest : IRequest
    {
        public Guid ID { get; set; }
    }
}
