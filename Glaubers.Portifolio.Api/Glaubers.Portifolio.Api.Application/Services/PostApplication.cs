using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Domain.Requests.Posts;
using Glaubers.Portifolio.Api.Application.Interfaces;
using Glaubers.Portifolio.Api.Application.ViewModels;
using Glaubers.Portifolio.Api.Domain.Interfaces.Repository;

namespace Glaubers.Portifolio.Api.Application.Services
{
    public class PostApplication : IPostApplication
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IPostRepository _repository;

        public PostApplication(IMapper mapper, IMediator mediator, IPostRepository repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<PostViewModel> Add(PostViewModel post)
        {
            var result = await _mediator.Send(new AddPostRequest { Post = _mapper.Map(post, new Post()) });

            return _mapper.Map(result, new PostViewModel());
        }

        public async Task Delete(Guid id)
        {
            await _mediator.Send(new DeletePostRequest { ID = id });
        }

        public async Task<List<PostViewModel>> Get()
        {
            var user = await _repository.Get().Include(p => p.User).Include(p => p.Category).ToListAsync();

            return _mapper.Map(user, new List<PostViewModel>());
        }

        public async Task<PostViewModel> GetByID(Guid id)
        {
            var post = await _repository.GetByIdAsync(id);

            return _mapper.Map(post == null ? new Post() : post, new PostViewModel());
        }

        // TODO: precisa verificar pois está pedindo que os Virtuals estejam preenchidos
        public async Task<PostViewModel> Update(PostViewModel post)
        {
            var result = await _mediator.Send(new UpdatePostRequest { Post = _mapper.Map(post, new Post()) });

            return _mapper.Map(result, new PostViewModel());
        }
    }
}
