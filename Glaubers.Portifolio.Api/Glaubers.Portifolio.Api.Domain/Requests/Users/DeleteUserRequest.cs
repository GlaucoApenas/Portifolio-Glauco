using MediatR;

namespace Glaubers.Portifolio.Api.Domain.Requests.Users
{
    public class DeleteUserRequest : IRequest
    {
        public Guid ID { get; set; }
    }
}
