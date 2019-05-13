using System.Linq;
using System.Threading.Tasks;
using AspVue.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspVue.Features.Filters
{
    [Route("api/[controller]")]
    public class FiltersController : Controller
    {
        private readonly AppDbContext _db;

        public FiltersController(AppDbContext db){
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            var brands = await _db.Brands
                .Select(x => x.Name)
                .ToListAsync();

            var storage = await _db.Storage
                .Select(x => x.Capacity)
                .ToListAsync();

            var colors = await _db.Colors
                .Select(x => x.Name)
                .ToListAsync();

            var os = await _db.OS
                .Select(x => x.Name)
                .ToListAsync();

            var features = await _db.Features
                .Select(x => x.Name)
                .ToListAsync();

            var results = new FiltersListViewModel {
                Brands = brands,
                Storage = storage,
                Colors = colors,
                OS = os,
                Features = features
            };

            return Ok(results);
        }
    }
}