using MediatR;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Domain.Requests.Posts;
using Glaubers.Portifolio.Api.Domain.Interfaces.Repository;

namespace Glaubers.Portifolio.Api.Domain.Commands
{
    public class PostCommandHandler : IRequestHandler<AddPostRequest, Post>, IRequestHandler<DeletePostRequest>, IRequestHandler<UpdatePostRequest, Post>
    {
        private readonly IPostRepository _repository;

        public PostCommandHandler(IPostRepository repository)
        {
            _repository = repository;
        }

        public async Task<Post> Handle(AddPostRequest request, CancellationToken cancellationToken)
        {
             return await _repository.AddAsync(request.Post);
        }

        public async Task Handle(DeletePostRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ID);
        }

        public async Task<Post> Handle(UpdatePostRequest request, CancellationToken cancellationToken)
        {
            var teste = await _repository.UpdateAsync(request.Post);

            return teste;
        }
    }
}
