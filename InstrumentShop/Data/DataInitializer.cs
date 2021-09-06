using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace InstrumentShop.Data
{
    public class DataInitializer
    {
        public static void SeedData(ApplicationDbContext dbContext, UserManager<IdentityUser> userManager)
        {
            dbContext.Database.Migrate();
            SeedCategory(dbContext);
            SeedRoles(dbContext);
            SeedUser(userManager);
            SeedProducts(dbContext);
        }

        public static void SeedUser(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByEmailAsync("stefan.holmberg@systementor.se").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "stefan.holmberg@systementor.se";
                user.Email = "stefan.holmberg@systementor.se";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Hejsan123#").Result;
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }

            if (userManager.FindByEmailAsync("elis.bihl@gmail.com").Result == null)
            {
                var user = new IdentityUser();
                user.UserName = "elis.bihl@gmail.com";
                user.Email = "elis.bihl@gmail.com";
                user.EmailConfirmed = true;

                IdentityResult result = userManager.CreateAsync(user, "Hejsan123#").Result;
                userManager.AddToRoleAsync(user, "Product Manager").Wait();

            }

        }

        private static void SeedRoles(ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                context.Roles.Add(new IdentityRole
                {
                    NormalizedName = "Admin",
                    Name = "Admin"
                });
            }
            if (!context.Roles.Any(r => r.Name == "Product Manager"))
            {
                context.Roles.Add(new IdentityRole
                {
                    NormalizedName = "Product Manager",
                    Name = "Product Manager"
                });
            }

            context.SaveChanges();
        }

        public static void SeedCategory(ApplicationDbContext dbContext)
        {

            if (!dbContext.Categories.Any(r => r.CategoryName == "Slaginstrument"))
            {
                var category1 = new Category()
                {
                    CategoryName = "Slaginstrument"
                };
                dbContext.Categories.Add(category1);
            }



            if (!dbContext.Categories.Any(r => r.CategoryName == "Gitarrer"))
            {
                var category2 = new Category()
                {
                    CategoryName = "Gitarrer"

                };
                dbContext.Categories.Add(category2);
            }
            dbContext.SaveChanges();


        }

        public static void SeedProducts(ApplicationDbContext dbContext)
        {
            
            if (!dbContext.Products.Any(r => r.ProductName == "Yamaha C40"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "Yamaha C40",
                    Pris = 1290,
                    Beskrivning = "Klassisk nylonsträngad gitarr",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Gitarrer"),
                    LastModified = DateTime.Now
                });
            }
            if (!dbContext.Products.Any(r => r.ProductName == "Takamine TC132SC"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "Takamine TC132SC",
                    Pris = 1290,
                    Beskrivning = "Klassisk nylonsträngad gitarr",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Gitarrer"),
                    LastModified = DateTime.Now

                });
            }

            if (!dbContext.Products.Any(r => r.ProductName == "Paiste 2002"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "Paiste 2002",
                    Pris = 4390,
                    Beskrivning = "Den klassiska ride-cymbalen från Paiste",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Slaginstrument"),
                    LastModified = DateTime.Now,
                    BildSource= "https://thumbs.static-thomann.de/thumb/orig/pics/bdb/133506/10398192_800.webp"

            });
            }

            if (!dbContext.Products.Any(r => r.ProductName == "Pearl Roadshow 22 Plus Charcoal M"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "Pearl Roadshow 22 Plus Charcoal M",
                    Pris = 4390,
                    Beskrivning = "Komplett pearl trumset",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Slaginstrument"),
                    LastModified = DateTime.Now

                });
            }

            dbContext.SaveChanges();
        }
    }
}
