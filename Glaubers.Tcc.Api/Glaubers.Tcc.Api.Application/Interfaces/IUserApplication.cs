using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Glaubers.Tcc.Api.Application.ViewModels;

namespace Glaubers.Tcc.Api.Application.Interfaces
{
    public interface IUserApplication
    {
        Task Delete(Guid id);
        Task<List<UserViewModel>> Get();
        Task<UserViewModel> GetByID(Guid id);
        Task<UserViewModel> Add(UserViewModel user);
        Task<UserViewModel> Update(UserViewModel user);

    }
}
