using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentShop.Pages.Admin.Categories
{
    [Authorize(Roles = "Admin, Product Manager")]

    public class ListCategoriesModel : PageModel
    {
        public readonly ApplicationDbContext _DbContext;

        public ListCategoriesModel(ApplicationDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public class CategoryItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        public List<CategoryItem> Lista { get; set; }

        public void OnGet()
        {
            Lista = _DbContext.Categories.Select(r => new CategoryItem()
            {
                Id = r.Id,
                Name = r.CategoryName,
            }).ToList();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

            }
            return Page();
        }

    }
}
