using MediatR;
using Glaubers.Portifolio.Api.Domain.Models;

namespace Glaubers.Portifolio.Api.Domain.Requests.Posts
{
    public class AddPostRequest : IRequest<Post>
    {
        public Post Post { get; set; }
    }
}
