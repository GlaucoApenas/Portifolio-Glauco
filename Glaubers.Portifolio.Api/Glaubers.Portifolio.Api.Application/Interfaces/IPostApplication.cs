using Glaubers.Portifolio.Api.Application.ViewModels;

namespace Glaubers.Portifolio.Api.Application.Interfaces
{
    public interface IPostApplication
    {
        Task Delete(Guid id);
        Task<List<PostViewModel>> Get();
        Task<PostViewModel> GetByID(Guid id);
        Task<PostViewModel> Add(PostViewModel post);
        Task<PostViewModel> Update(PostViewModel post);
    }
}
