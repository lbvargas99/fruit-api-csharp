using Fruit.Crud.Core.Application.DTOs;
using Fruit.Crud.Core.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fruit.Crud.Core.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly IFruitService _fruitService;

        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] FruitDTO fruitDTO)
        {
            var result = await _fruitService.CreateAsync(fruitDTO);
            if (result.IsSuccess)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            var result = await _fruitService.GetAllAsync();
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetByIdAsync(int id)
        {
            var result = await _fruitService.GetByIdAsync(id);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
