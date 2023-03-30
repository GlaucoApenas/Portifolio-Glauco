using MediatR;
using Glaubers.Tcc.Api.Domain.Models;

namespace Glaubers.Tcc.Api.Domain.Requests.Users
{
    public class AddUserRequest : IRequest<User>
    {
        public User User { get; set; }
    }
}
