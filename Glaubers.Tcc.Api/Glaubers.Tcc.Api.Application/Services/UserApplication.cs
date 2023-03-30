using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Glaubers.Tcc.Api.Domain.Models;
using Glaubers.Tcc.Api.Domain.Requests.Users;
using Glaubers.Tcc.Api.Application.Interfaces;
using Glaubers.Tcc.Api.Application.ViewModels;
using Glaubers.Tcc.Api.Domain.Interfaces.Repository;

namespace Glaubers.Tcc.Api.Application.Services
{
    public class UserApplication : IUserApplication
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IUserRepository _repository;

        public UserApplication(IMapper mapper, IMediator mediator, IUserRepository repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<UserViewModel> Add(UserViewModel user)
        {
            var result = await _mediator.Send(new AddUserRequest { User = _mapper.Map(user, new User()) });

            return _mapper.Map(result, new UserViewModel());
        }

        public async Task Delete(Guid id)
        {
            await _mediator.Send(new DeleteUserRequest { ID = id });
        }

        public async Task<List<UserViewModel>> Get()
        {
            var user = await _repository.Get().ToListAsync();

            return _mapper.Map(user, new List<UserViewModel>());
        }

        public async Task<UserViewModel> GetByID(Guid id)
        {
            var user = await _repository.GetByIdAsync(id);

            return _mapper.Map(user == null ? new User() : user, new UserViewModel());
        }

        public async Task<UserViewModel> Update(UserViewModel user)
        {
            var result = await _mediator.Send(new UpdateUserRequest { User = _mapper.Map(user, new User()) });

            return _mapper.Map(result, new UserViewModel());
        }
    }
}
