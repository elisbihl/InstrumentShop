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

    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty] public string Namn { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var n = new Category();
                n.CategoryName = Namn;
                _dbContext.Add(n);
                _dbContext.SaveChanges();
                return RedirectToPage("/Admin/Categories/ListCategories");
            }

            return Page();
        }

        public void OnGet()
        {

        }
    }
}
