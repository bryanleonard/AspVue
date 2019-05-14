using Microsoft.AspNetCore.Mvc;
using AspVue.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AspVue.Features.Products
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly AppDbContext _db;

        public ProductsController(AppDbContext db){
            _db = db;
        }

        // [HttpGet]
        // public async Task<IActionResult> Find(){
        //     var products = await _db.Products.ToListAsync();
        //     return Ok(products);
        // }

        [HttpGet]
        public async Task<IActionResult> Find(
            string q, string brands, int? minPrice, int? maxPrice, int? minScreen, 
            int? maxScreen, string capacity, string colors, string os, string features)
        {
            var Query = $"%{q?.ToLower()}%";
            var Brands = string.IsNullOrEmpty(brands) ? new List<string>() : brands.Split('|').ToList();
            var Capacity = string.IsNullOrEmpty(capacity) ? new List<string>() : capacity.Split('|').ToList();
            var Colors = string.IsNullOrEmpty(colors) ? new List<string>() : colors.Split('|').ToList();
            var OS = string.IsNullOrEmpty(os) ? new List<string>() : os.Split('|').ToList();
            var Features = string.IsNullOrEmpty(features) ? new List<string>() : features.Split('|').ToList();

            var products = await _db.Products
                .Where(x =>
                    string.IsNullOrEmpty(q) ||
                    (
                        EF.Functions.Like(x.Name.ToLower(), Query) ||
                        EF.Functions.Like(x.ShortDescription.ToLower(), Query) ||
                        EF.Functions.Like(x.Description.ToLower(), Query) ||
                        EF.Functions.Like(x.Brand.Name.ToLower(), Query) ||
                        EF.Functions.Like(x.OS.Name.ToLower(), Query) ||
                        x.ProductFeatures.Any(f => EF.Functions.Like(f.Feature.Name.ToLower(), Query))
                    )
                )
                .Where(x => Brands.Any() == false || Brands.Contains(x.Brand.Name, StringComparer.CurrentCultureIgnoreCase))
                .Where(x => minPrice.HasValue == false || x.ProductVariants.Any(v => v.Price >= minPrice.Value))
                .Where(x => maxPrice.HasValue == false || x.ProductVariants.Any(v => v.Price <= maxPrice.Value))
                .Where(x => minScreen.HasValue == false || x.ScreenSize >= System.Convert.ToDecimal(minScreen.Value))
                .Where(x => maxScreen.HasValue == false || x.ScreenSize <= Convert.ToDecimal(maxScreen.Value))
                .Where(x => Capacity.Any() == false || x.ProductVariants.Any(v => Capacity.Contains(v.Storage.Capacity.ToString(), StringComparer.CurrentCultureIgnoreCase)))
                .Where(x => Colors.Any() == false || x.ProductVariants.Any(v => Colors.Contains(v.Color.Name, StringComparer.CurrentCultureIgnoreCase)))
                .Where(x => OS.Any() == false || OS.Contains(x.OS.Name, StringComparer.CurrentCultureIgnoreCase))
                .Where(x => Features.Any() == false || Features.All(f => x.ProductFeatures.Any(pf => pf.Feature.Name == f)))
                .Select(x => new ProductListViewModel
                {
                    Id = x.Id,
                    Slug = x.Slug,
                    Name = x.Name,
                    ShortDescription = x.ShortDescription,
                    Thumbnail = x.Thumbnail,
                    Price = x.ProductVariants.OrderBy(v => v.Price).First().Price
                })
                .ToListAsync();
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