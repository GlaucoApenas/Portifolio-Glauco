using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Glaubers.Portifolio.Api.Application.Interfaces;
using Glaubers.Portifolio.Api.Application.ViewModels;

namespace Glaubers.Portifolio.Api.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostApplication _application;

        public PostController(IPostApplication application)
        {
            _application = application;
        }

        [HttpGet]
        [Route("v1.0/posts")]
        public async Task<ActionResult> Get()
        {
            var users = await _application.Get();

            return Ok(users);
        }

        [HttpGet]
        [Route("v1.0/posts/{id}")]
        public async Task<ActionResult> GetByID(Guid id)
        {
            var user = await _application.GetByID(id);

            if (user.ID == Guid.Empty)
                return NotFound();

            else
                return Ok(user);
        }

        [HttpPost]
        [Route("v1.0/posts/add")]
        public async Task<ActionResult> Add(PostViewModel user)
        {
            try
            {
                user = await _application.Add(user);

                return Ok(user);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("v1.0/posts/update")]
        public async Task<ActionResult> Update(PostViewModel user)
        {
            if (user.ID == Guid.Empty)
                return NotFound();
            else
            {
                user = await _application.Update(user);

                return Ok(user);
            }
        }

        [HttpDelete]
        [Route("v1.0/posts/delete")]
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
