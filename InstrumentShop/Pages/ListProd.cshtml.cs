using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace InstrumentShop.Pages
{
    public class ListProdModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;


        public ListProdModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<ProductItem> Lista { get; set; }

        public class ProductItem
        {
            public string Namn { get; set; }
            public string Bes { get; set; }
            public int Id { get; set; }
            public string BildSrc { get; set; }
            public int Category { get; set; }
        }

        public void OnGet(int id)
        {
        
            Lista = _dbContext.Products.Select(r => new ProductItem
            {
                Namn = r.ProductName,
                Bes = r.Beskrivning,
                Id = r.Id,
                BildSrc = r.BildSource,
                Category = r.Kategori.Id
            }).ToList();
            var imte = from r in Lista
                where r.Category == id
                orderby r.Namn ascending
                select r;
            Lista = imte.ToList();
        }
    }
}
