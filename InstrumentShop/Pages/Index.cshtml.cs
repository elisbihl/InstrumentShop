using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Http;

namespace InstrumentShop.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ApplicationDbContext _dbContext;


        public IndexModel(ILogger<IndexModel> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public List<Kategori> Lista { get; set; }

        public IFormFile Bild { get; set; }

        public class Kategori
        {
            public int Id { get; set; }
            public string KatNamn { get; set; }
            public string Bild { get; set; }
        }

        public void OnGet()
        {
            Lista = _dbContext.Categories.Select(r => new Kategori
            {
                KatNamn = r.CategoryName,
                Id = r.Id,
                Bild = r.CatImg
            }).ToList();
        }
    }
}
