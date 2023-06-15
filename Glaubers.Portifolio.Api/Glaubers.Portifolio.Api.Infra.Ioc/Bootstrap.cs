using MediatR;
using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;
using Glaubers.Portifolio.Api.Application.Services;
using Glaubers.Portifolio.Api.Domain.Requests.Users;
using Glaubers.Portifolio.Api.Domain.Requests.Posts;
using Glaubers.Portifolio.Api.Infra.Data.Repository;
using Glaubers.Portifolio.Api.Application.Interfaces;
using Glaubers.Portifolio.Api.Domain.Requests.Categories;
using Glaubers.Portifolio.Api.Domain.Interfaces.Repository;

namespace Glaubers.Portifolio.Api.Infra.Ioc
{
    public static class Bootstrap
    {
        public static void Register(this IServiceCollection services)
        {
            // Application Services
            services.AddScoped<IPostApplication, PostApplication>();
            services.AddScoped<IUserApplication, UserApplication>();
            services.AddScoped<ICategoryApplication, CategoryApplication>();

            // Domain - Command - User
            services.AddScoped<IRequestHandler<DeleteUserRequest>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<AddUserRequest, User>, UserCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateUserRequest, User>, UserCommandHandler>();

            // Domain - Command - Category
            services.AddScoped<IRequestHandler<DeleteCategoryRequest>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<AddCategoryRequest, Category>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryRequest, Category>, CategoryCommandHandler>();

            // Domain - Command - Post
            services.AddScoped<IRequestHandler<DeletePostRequest>, PostCommandHandler>();
            services.AddScoped<IRequestHandler<AddPostRequest, Post>, PostCommandHandler>();
            services.AddScoped<IRequestHandler<UpdatePostRequest, Post>, PostCommandHandler>();
        }

        public static void Register<C>(this IServiceCollection services) where C : DbContext
        {
            // Repositories
            services.AddScoped<IUserRepository, UserRepository<C>>();
            services.AddScoped<IPostRepository, PostRepository<C>>();
            services.AddScoped<ICategoryRepository, CategoryRepository<C>>();
        }
    }
}