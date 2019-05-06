using Microsoft.AspNetCore.Mvc;
using AspVue.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AspVue.Features.Products
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _db;

        public ProductsController(AppDbContext db){
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Find(){
            var products = await _db.Products.ToListAsync();
            return Ok(products);
        }


        [HttpGet("{slug}")]
        public async Task<IActionResult> Get(string slug){
            var product = await _db.Products.SingleOrDefaultAsync( x => x.Slug == slug);
            if (product == null) {
                return NotFound();
            }

            return Ok(product);
        }

    }
}