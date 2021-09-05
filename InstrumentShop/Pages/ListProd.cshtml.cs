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

        public string BildSource { get; set; }

        public List<Products> Lista { get; set; }



        public void OnGet(int id)
        {
            var temp = _dbContext.Products.Where(r => r.Kategori.Id == id);
            var imte = from r in _dbContext.Products
                       where r.Kategori.Id == id
                orderby r.ProductName ascending
                select r;
            Lista = imte.ToList();
        }
    }
}
