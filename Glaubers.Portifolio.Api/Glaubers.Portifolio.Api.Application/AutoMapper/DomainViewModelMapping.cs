using AutoMapper;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Application.ViewModels;

namespace Glaubers.Portifolio.Api.Application.AutoMapper
{
    public class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping()
        {
            CreateMap<User, UserViewModel>();
            CreateMap<Post, PostViewModel>();
            CreateMap<Category, CategoryViewModel>();
        }
    }
}
