using ECommerce.Application.Contracts;
using ECommerce.Application.DTOs.BasketDtos;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace eCommerce.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BasketController : ControllerBase
    {
        private readonly IBaskcetService _basketService;

        public BasketController(IBaskcetService basketService)
        {
            _basketService = basketService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BasketDto>> GetBasket(string id, CancellationToken ct)
        {
            var result = await _basketService.GetBasketAsync(id, ct);
            return ToActionResult(result);
        }

        [HttpPost]
        public async Task<ActionResult<BasketDto>> CreateOrUpdate(BasketDto basketDto, CancellationToken ct)
        {
            // Note: Your image showed GetBasketAsync being called here; 
            // usually, this would be an Update/Create call.
            var result = await _basketService.CreateOrUpdateBasket(basketDto, ct:ct);
            return ToActionResult(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteBasket(string id, CancellationToken ct)
        {
            var result = await _basketService.DeleteBasketAsync(id, ct);
            return ToActionResult(result);
        }

        // Implementation of the missing helper method
        private ActionResult ToActionResult<T>(T result)
        {
            if (result == null) return NotFound();
            return Ok(result);
        }
    }
}
