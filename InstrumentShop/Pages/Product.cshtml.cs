using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentShop.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Id { get; set; }
        public string Namn { get; set; }
        public string Band { get; set; }
        public string Beskrivning { get; set; }
        public int Pris { get; set; }
        public IFormFile Bild { get; set; }
        public string BildSource { get; set; }

        public void OnGet(int id)
        {
            var product = _dbContext.Products.First(r => r.Id == id);
            Id = product.Id;
            Namn = product.ProductName;
            Beskrivning = product.Beskrivning;
            Pris = product.Pris;
            var temp = _dbContext.Products.Where(r => r.Kategori.Id == Id);
        }
    }
}
