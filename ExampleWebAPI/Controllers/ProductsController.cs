using ExampleWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ShopContext _context;

        public ProductsController(ShopContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        [HttpGet]
        //Example with IEnumerable Type
        //public async Task<IEnumerable<Product>> GetAllProducts()
        //{
        //    return await _context.Products.ToListAsync();
        //}
        public async Task<ActionResult> GetAllProducts()
        {
            return Ok(await _context.Products.ToArrayAsync());
        }

        [HttpGet("{id}")]
        //[Route("{id")] moved the id into the above HttpGET call

        public async Task<ActionResult> GetProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}
