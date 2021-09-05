using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentShop.Pages.Admin.Categories
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Category Category { get; set; }


        public IActionResult OnGet(int id)
        {
            Category = _dbContext.Categories.First(r => r.Id == id);

            if (Category == null)
            {
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Remove(Category);
                _dbContext.SaveChanges();
            }

            return RedirectToPage("/admin/categories/listcategories");
        }
    }
}

