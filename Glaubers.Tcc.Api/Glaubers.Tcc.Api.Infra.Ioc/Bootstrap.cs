using MediatR;
using Microsoft.EntityFrameworkCore;
using Glaubers.Tcc.Api.Domain.Models;
using Glaubers.Tcc.Api.Domain.Commands;
using Glaubers.Tcc.Api.Application.Services;
using Glaubers.Tcc.Api.Domain.Requests.Users;
using Glaubers.Tcc.Api.Infra.Data.Repository;
using Glaubers.Tcc.Api.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Glaubers.Tcc.Api.Domain.Interfaces.Repository;

namespace Glaubers.Tcc.Api.Infra.Ioc
{
    public static class Bootstrap
    {
        public static void Register(this IServiceCollection services)
        {
            // Application Services
            services.AddScoped<IUserApplication, UserApplication>();

            // Domain - Command - User
            services.AddScoped<IRequestHandler<DeleteUserRequest>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserRequest, User>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<AddUserRequest, User>, UserCommandHandler>();
        }

        public static void Register<C>(this IServiceCollection services) where C : DbContext
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository<C>>();
        }
    }
}