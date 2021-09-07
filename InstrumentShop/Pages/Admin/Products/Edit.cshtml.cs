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
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public EditModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty, Required, MaxLength(50)]
        public string Namn { get; set; }
        [BindProperty, Range(1, 999999), Required]
        public int Pris { get; set; }
        [BindProperty]
        public string Beskrivning { get; set; }
        [BindProperty]
        public int Category { get; set; }
        public List<SelectListItem> Categories { get; set; }

        public DateTime LastModified { get; set; }
        [BindProperty]
        public string BildSrc { get; set; }
        public IFormFile Bild { get; set; }

        public void OnGet(int id)
        {
            Categories = _dbContext.Categories.Select(e => new SelectListItem
            {
                Text = e.CategoryName,
                Value = e.Id.ToString(),
            }).ToList();
            var product = _dbContext.Products.First(r => r.Id == id);

            Namn = product.ProductName;
            Pris = product.Pris;
            Beskrivning = product.Beskrivning;
            LastModified = product.LastModified;
            BildSrc = product.BildSource;

        }


        public IActionResult OnPost(int id)
        {
            if (ModelState.IsValid)
            {
                var product = _dbContext.Products.First(product => product.Id == id);
                product.ProductName = Namn;
                product.Pris = Pris;
                product.Beskrivning = Beskrivning;
                product.Kategori = _dbContext.Categories.First(r => r.Id == Category);
                product.LastModified = DateTime.Now;
                product.BildSource = BildSrc;
                _dbContext.SaveChanges();
                return RedirectToPage("/Admin/Products/List");
            }

            Categories = _dbContext.Categories.Select(e => new SelectListItem
            {
                Text = e.CategoryName,
                Value = e.Id.ToString(),
            }).ToList();
            return Page();
        }
    }
}
