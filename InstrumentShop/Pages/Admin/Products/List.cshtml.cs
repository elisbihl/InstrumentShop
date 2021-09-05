using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentShop.Pages.Admin.Products
{
    public class ListModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        public ListModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ProductItem> ProduktLista { get; set; }

        public class ProductItem
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Pris { get; set; }
            public string Kate { get; set; }
            public string Bes { get; set; }
        }

        public void OnGet()
        {
            ProduktLista = _dbContext.Products.Select(r => new ProductItem
            {
                Name = r.ProductName,
                Pris = r.Pris,
                Kate = r.Kategori.CategoryName,
                Id = r.Id,
                Bes = r.Beskrivning
            }).ToList();
        }
    }
}
