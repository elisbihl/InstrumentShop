using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentShop.Pages.Admin.Products
{
    [Authorize(Roles = "Admin, Product Manager")]

    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public DeleteModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Data.Products Product { get; set; }


        public IActionResult OnGet(int id)
        {
            Product = _dbContext.Products.First(r => r.Id == id);

            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _dbContext.Remove(Product);
                _dbContext.SaveChanges();
            }

            return RedirectToPage("/admin/products/list");
        }
    }
}
