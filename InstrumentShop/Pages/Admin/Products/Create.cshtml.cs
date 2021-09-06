using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InstrumentShop.Pages.Admin.Products
{
    [Authorize(Roles = "Admin, Product Manager")]

    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;
 

        public CreateModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
         
        }
        [BindProperty, Required]
        public string Namn { get; set; }
        [BindProperty]
        public string Beskrivning { get; set; }
        [BindProperty, Required]
        public int Pris { get; set; }
        [BindProperty]
        public int Selected { get; set; }
        public List<SelectListItem> Lista { get; set; }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                var item = new Data.Products();
                item.ProductName = Namn;
                item.Beskrivning = Beskrivning;
                item.Pris = Pris;
                item.Kategori = _dbContext.Categories.First(r => r.Id == Selected);
                _dbContext.Add(item);
                _dbContext.SaveChanges();
                return RedirectToPage("/admin/products/list");
            }
            Lista = _dbContext.Categories.Select(r => new SelectListItem()
            {
                Text = r.CategoryName,
                Value = r.Id.ToString(),
            }).ToList();
            return Page();
        }

        public void OnGet()
        {
            Lista = _dbContext.Categories.Select(r => new SelectListItem()
            {
                Text = r.CategoryName,
                Value = r.Id.ToString(),
            }).ToList();
        }
    }
}
