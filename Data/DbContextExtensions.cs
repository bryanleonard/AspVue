using AspVue.Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace AspVue.Data
{
    public static class DbContextExtensions
    {
        public static UserManager<AppUser> UserManager { get; set; }
    
        public static void EnsureSeeded(this AppDbContext context)
        {
            if (UserManager.FindByEmailAsync("bleonard@acrtinc.com").GetAwaiter().GetResult() == null)
            {
                var user = new AppUser
                {
                    FirstName = "Bryan",
                    LastName = "Leonard",
                    UserName = "bleonard@acrtinc.com",
                    Email = "bleonard@acrtinc.com",
                    EmailConfirmed = true,
                    LockoutEnabled = false
                };

                UserManager.CreateAsync(user, "Password1*").GetAwaiter().GetResult();
            }
        }
    }
}