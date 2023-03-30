﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Glaubers.Tcc.Api.Domain.Models;
using Glaubers.Tcc.Api.Domain.Requests.Users;
using Glaubers.Tcc.Api.Domain.Interfaces.Repository;

namespace Glaubers.Tcc.Api.Domain.Commands
{
    public class UserCommandHandler : IRequestHandler<AddUserRequest, User>, IRequestHandler<DeleteUserRequest>, IRequestHandler<UpdateUserRequest, User>
    {
        private readonly IUserRepository _repository;

        public UserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<User> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
             return await _repository.AddAsync(request.User);
        }

        public async Task Handle(DeleteUserRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ID);
        }

        public async Task<User> Handle(UpdateUserRequest request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.User);
        }
    }
}
