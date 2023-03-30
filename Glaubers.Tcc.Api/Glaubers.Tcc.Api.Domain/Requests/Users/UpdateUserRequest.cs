using MediatR;
using Glaubers.Tcc.Api.Domain.Models;

namespace Glaubers.Tcc.Api.Domain.Requests.Users
{
    public class UpdateUserRequest : IRequest<User>
    {
        public User User { get; set; }
    }
}
