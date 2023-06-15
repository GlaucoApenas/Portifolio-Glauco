using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Glaubers.Portifolio.Api.Domain.Models;
using Glaubers.Portifolio.Api.Application.Interfaces;
using Glaubers.Portifolio.Api.Application.ViewModels;
using Glaubers.Portifolio.Api.Domain.Requests.Categories;
using Glaubers.Portifolio.Api.Domain.Interfaces.Repository;

namespace Glaubers.Portifolio.Api.Application.Services
{
    public class CategoryApplication : ICategoryApplication
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly ICategoryRepository _repository;

        public CategoryApplication(IMapper mapper, IMediator mediator, ICategoryRepository repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _repository = repository;
        }

        public async Task<CategoryViewModel> Add(CategoryViewModel category)
        {
            try
            {
                var result = await _mediator.Send(new AddCategoryRequest { Category = _mapper.Map(category, new Category()) });

                return _mapper.Map(result, new CategoryViewModel());
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public async Task Delete(Guid id)
        {
            await _mediator.Send(new DeleteCategoryRequest { ID = id });
        }

        public async Task<List<CategoryViewModel>> Get()
        {
            var categories = await _repository.Get().ToListAsync();

            return _mapper.Map(categories, new List<CategoryViewModel>());
        }

        public async Task<CategoryViewModel> GetByID(Guid id)
        {
            var category = await _repository.GetByIdAsync(id);

            return _mapper.Map(category == null ? new Category() : category, new CategoryViewModel());
        }

        public async Task<CategoryViewModel> Update(CategoryViewModel category)
        {
            var result = await _mediator.Send(new UpdateCategoryRequest { Category = _mapper.Map(category, new Category()) });

            return _mapper.Map(result, new CategoryViewModel());
        }
    }
}
