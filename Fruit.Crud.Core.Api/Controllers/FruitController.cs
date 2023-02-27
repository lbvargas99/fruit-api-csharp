using Fruit.Crud.Core.Application.DTOs;
using Fruit.Crud.Core.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Fruit.Crud.Core.Api.Controllers
{
    [Route("api/fruit")]
    [ApiController]
    public class FruitController : ControllerBase
    {
        private readonly IFruitService _fruitService;

        public FruitController(IFruitService fruitService)
        {
            _fruitService = fruitService;
        }

        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody] FruitDTO fruitDTO)
        {
            var result = await _fruitService.Create(fruitDTO);
            if (result.IsSuccess)
                return Ok(result);
            
            return BadRequest(result);
        }

    }
}
