using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InstrumentShop.Pages
{
    public class SearchResultModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty(SupportsGet = true)]
        public List<Products> Lista { get; set; }
        public string Search { get; set; }

        public SearchResultModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public void OnGet(string query)
        {
            Search = query;
            var temp = from r in _dbContext.Products
                select r;
            if (!string.IsNullOrEmpty(Search))
            {
                temp = temp.Where(r =>
                    r.ProductName.Contains(Search) || r.Beskrivning.Contains(Search));

            }

            Lista = temp.ToList();
        }
    }
}
