using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentShop.Pages.Admin.Categories
{
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

        public List<Category> Lista { get; set; }

        public void OnGet()
        {
            Lista = _DbContext.Categories.Select(r => new Category()
            {
                Id = r.Id,
                CategoryName = r.CategoryName,
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
