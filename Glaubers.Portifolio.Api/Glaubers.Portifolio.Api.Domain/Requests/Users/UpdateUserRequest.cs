using MediatR;
using Glaubers.Portifolio.Api.Domain.Models;

namespace Glaubers.Portifolio.Api.Domain.Requests.Users
{
    public class UpdateUserRequest : IRequest<User>
    {
        public User User { get; set; }
    }
}
