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
            SeedRoles(dbContext);
            SeedUser(userManager);
            SeedCategory(dbContext);
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
                    CategoryName = "Slaginstrument",
                    CatImg = "https://rolandcorp.com.au/blog/wp-content/uploads/2020/09/record-e-drums-960x600-1.jpg"
                };
                dbContext.Categories.Add(category1);
            }



            if (!dbContext.Categories.Any(r => r.CategoryName == "Akustiska Gitarrer"))
            {
                var category2 = new Category()
                {
                    CategoryName = "Akustiska Gitarrer",
                    CatImg = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQB3mMOCMXs02vSqeQX-MNSNus4TbHEYIZiaA&usqp=CAU"

                };
                dbContext.Categories.Add(category2);
            }

            if (!dbContext.Categories.Any(r => r.CategoryName == "Synthar"))
            {
                var category2 = new Category()
                {
                    CategoryName = "Synthar",
                    CatImg = "https://www.musictech.net/wp-content/uploads/2020/10/polysynth-buyers-guide@1400x1050.jpg"

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
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Akustiska Gitarrer"),
                    LastModified = DateTime.Now,
                    BildSource = "https://thumbs.static-thomann.de/thumb/orig/pics/prod/135317.webp"
                });
            }
            if (!dbContext.Products.Any(r => r.ProductName == "Takamine TC132SC"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "Takamine TC132SC",
                    Pris = 12900,
                    Beskrivning = "Klassisk nylonsträngad gitarr",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Akustiska Gitarrer"),
                    LastModified = DateTime.Now,
                    BildSource = "https://thumbs.static-thomann.de/thumb/orig/pics/prod/169991.webp"

                });
            }
            if (!dbContext.Products.Any(r => r.ProductName == "Hanika 54PF"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "Hanika 54PF",
                    Pris = 11900,
                    Beskrivning = "Klassisk nylonsträngad gitarr",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Akustiska Gitarrer"),
                    LastModified = DateTime.Now,
                    BildSource = "https://thumbs.static-thomann.de/thumb/orig/pics/prod/379188.webp"

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
                    Pris = 6300,
                    Beskrivning = "Komplett pearl trumset",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Slaginstrument"),
                    LastModified = DateTime.Now,
                    BildSource = "https://thumbs.static-thomann.de/thumb/orig/pics/bdb/521883/16439406_800.webp"
                });
            }

            if (!dbContext.Products.Any(r => r.ProductName == "The Prophet 5"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "The Prophet 5",
                    Pris = 6300,
                    Beskrivning = "Klassisk synth",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Synthar"),
                    LastModified = DateTime.Now,
                    BildSource = "https://support.musicgateway.com/wp-content/uploads/2021/04/vintage-synth-3.png"
                });
            }

            if (!dbContext.Products.Any(r => r.ProductName == "The Jupiter 8"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "The Jupiter 8",
                    Pris = 6300,
                    Beskrivning = "Klassisk synth från Roland",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Synthar"),
                    LastModified = DateTime.Now,
                    BildSource = "https://support.musicgateway.com/wp-content/uploads/2021/04/Copy-of-800-x-500-Blog-Post-72.png"
                });
            }

            if (!dbContext.Products.Any(r => r.ProductName == "The DX7"))
            {
                dbContext.Products.Add(new Products()
                {
                    ProductName = "The DX7",
                    Pris = 6300,
                    Beskrivning = "Klassisk synth från Yamaha",
                    Kategori = dbContext.Categories.First(r => r.CategoryName == "Synthar"),
                    LastModified = DateTime.Now,
                    BildSource = "https://support.musicgateway.com/wp-content/uploads/2021/04/Copy-of-800-x-500-Blog-Post-2-4.png"
                });
            }

            dbContext.SaveChanges();
        }
    }
}
