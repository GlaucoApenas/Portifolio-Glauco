using AutoMapper;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Application.ViewModels;

namespace Glaubers.Portifolio.Api.Application.AutoMapper
{
    public class ViewModelDomainMapping : Profile
    {
        public ViewModelDomainMapping()
        {
            CreateMap<UserViewModel, User>();
            CreateMap<PostViewModel, Post>();
            CreateMap<CategoryViewModel, Category>();
        }
    }
}
