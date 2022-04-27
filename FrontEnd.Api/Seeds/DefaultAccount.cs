using FrondEnd.Shared.Models;
using FrontEnd.Api.Contexts;
using FrontEnd.Api.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FrontEnd.Api.Seeds
{
    public static class DefaultAccount
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            var authService = serviceProvider.GetRequiredService<ApplicationDbContext>();

            var data = await authService.Products.ToListAsync();
            authService.Products.RemoveRange(data);
            await authService.SaveChangesAsync();

            var defaultUser = new ApplicationUser
            {
                UserName = "Test",
                Password = "test"
            };
            if (authService.Users.All(u => u.UserName != defaultUser.UserName && u.UserName != defaultUser.UserName))
            {
                await authService.Users.AddAsync(defaultUser);
                await authService.SaveChangesAsync();
            }

            if (!authService.Products.Any())
            {

                var prods = new List<Products>
                {
                    new Products("Bananas", 5,200),
                    new Products("Orange", 6,200),
                    new Products("Apple", 10,200),
                    new Products("PineApple", 15,200),
                    new Products("LapTop", 500,1000),
                    new Products("Car Audi", 40000,100),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                    new Products("car VW", 15000,200),
                };
                await authService.Products.AddRangeAsync(prods);
                await authService.SaveChangesAsync();
            }


        }
    }
}
