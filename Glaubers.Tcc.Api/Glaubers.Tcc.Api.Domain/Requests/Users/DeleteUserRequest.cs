using MediatR;

namespace Glaubers.Tcc.Api.Domain.Requests.Users
{
    public class DeleteUserRequest : IRequest
    {
        public Guid ID { get; set; }
    }
}
