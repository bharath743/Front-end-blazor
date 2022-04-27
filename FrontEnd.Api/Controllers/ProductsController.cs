using FrondEnd.Shared.Models;
using FrontEnd.Api.Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FrontEnd.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("get-products")]
        public async Task<IActionResult> GetProductListAsync()
        {
            try
            {
                var data = await _context.Products.ToListAsync();
                return Ok(new Response<IReadOnlyCollection<Products>>("SUCCESS", $"List of {data.Count} products", data));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
