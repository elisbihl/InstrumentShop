using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentShop.Pages.Admin.Categories
{
    [Authorize(Roles = "Admin, Product Manager")] 
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty, MaxLength(30), Required]
        public string Namn { get; set; }

        [BindProperty]
        public string BildSrc { get; set; }

        public void OnGet(int id)
        {
            var temp = _dbContext.Categories.First(r => r.Id == id);
            Namn = temp.CategoryName;
            BildSrc = temp.CatImg;
        }

        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var temp = _dbContext.Categories.First(r => r.Id == id);
                temp.CategoryName = Namn;
                temp.CatImg = BildSrc;
                _dbContext.Add(temp);
                _dbContext.SaveChanges();
                return RedirectToPage("/admin/categories/listcategories");
            }

            return Page();
        }
    }
}
