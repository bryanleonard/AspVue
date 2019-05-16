using System.Threading.Tasks;
using AspVue.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspVue.Features.Users
{
    [Authorize]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        
        private readonly AppDbContext _db;
        public UsersController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _db.Users.ToListAsync());
            // return Ok(new string[] { "value 1", "value 2" });
        }
    }
}