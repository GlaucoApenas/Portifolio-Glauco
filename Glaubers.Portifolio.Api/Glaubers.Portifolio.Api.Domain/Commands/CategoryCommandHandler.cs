using MediatR;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Domain.Requests.Categories;
using Glaubers.Portifolio.Api.Domain.Interfaces.Repository;

namespace Glaubers.Portifolio.Api.Domain.Commands
{
    public class CategoryCommandHandler : IRequestHandler<AddCategoryRequest, Category>, IRequestHandler<DeleteCategoryRequest>, IRequestHandler<UpdateCategoryRequest, Category>
    {
        private readonly ICategoryRepository _repository;

        public CategoryCommandHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<Category> Handle(AddCategoryRequest request, CancellationToken cancellationToken)
        {
             return await _repository.AddAsync(request.Category);
        }

        public async Task Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.ID);
        }

        public async Task<Category> Handle(UpdateCategoryRequest request, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(request.Category);
        }
    }
}
