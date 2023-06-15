using Glaubers.Portifolio.Api.Application.ViewModels;

namespace Glaubers.Portifolio.Api.Application.Interfaces
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
