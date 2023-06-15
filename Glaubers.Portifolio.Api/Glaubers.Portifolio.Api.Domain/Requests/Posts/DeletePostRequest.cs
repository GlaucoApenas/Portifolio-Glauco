using MediatR;

namespace Glaubers.Portifolio.Api.Domain.Requests.Posts
{
    public class DeletePostRequest : IRequest
    {
        public Guid ID { get; set; }
    }
}
