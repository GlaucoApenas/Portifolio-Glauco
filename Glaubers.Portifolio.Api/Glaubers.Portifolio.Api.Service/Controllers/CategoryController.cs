using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Glaubers.Portifolio.Api.Application.Interfaces;
using Glaubers.Portifolio.Api.Application.ViewModels;

namespace Glaubers.Portifolio.Api.Controllers
{
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryApplication _application;

        public CategoryController(ICategoryApplication application)
        {
            _application = application;
        }

        [HttpGet]
        [Route("v1.0/categories")]
        public async Task<ActionResult> Get()
        {
            var categories = await _application.Get();

            return Ok(categories);
        }

        [HttpGet]
        [Route("v1.0/categories/{id}")]
        public async Task<ActionResult> GetByID(Guid id)
        {
            var category = await _application.GetByID(id);

            if (category.ID == Guid.Empty)
                return NotFound();

            else
                return Ok(category);
        }

        [HttpPost]
        [Route("v1.0/categories/add")]
        public async Task<ActionResult> Add(CategoryViewModel category)
        {
            try
            {
                category = await _application.Add(category);

                return Ok(category);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("v1.0/categories/update")]
        public async Task<ActionResult> Update(CategoryViewModel category)
        {
            if (category.ID == Guid.Empty)
                return NotFound();
            else
            {
                category = await _application.Update(category);

                return Ok(category);
            }
        }

        [HttpDelete]
        [Route("v1.0/categories/delete")]
        public async Task<ActionResult> Delete(Guid id)
        {
            if (id == Guid.Empty)
                return NotFound();
            else
            {
                await _application.Delete(id);

                return Ok(id);
            }
        }
    }
}
