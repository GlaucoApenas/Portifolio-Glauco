using Glaubers.Portifolio.Api.Application.ViewModels;

namespace Glaubers.Portifolio.Api.Application.Interfaces
{
    public interface ICategoryApplication
    {
        Task Delete(Guid id);
        Task<List<CategoryViewModel>> Get();
        Task<CategoryViewModel> GetByID(Guid id);
        Task<CategoryViewModel> Add(CategoryViewModel category);
        Task<CategoryViewModel> Update(CategoryViewModel category);
    }
}
