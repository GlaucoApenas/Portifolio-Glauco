using AutoMapper;
using Glaubers.Tcc.Api.Domain.Models;
using Glaubers.Tcc.Api.Application.ViewModels;

namespace Glaubers.Tcc.Api.Application.AutoMapper
{
    public class DomainViewModelMapping : Profile
    {
        public DomainViewModelMapping()
        {
            CreateMap<User, UserViewModel>();
        }
    }
}
