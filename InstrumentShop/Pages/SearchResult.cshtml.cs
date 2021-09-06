using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstrumentShop.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace InstrumentShop.Pages
{
    public class SearchResultModel : PageModel
    {
        private readonly ApplicationDbContext _dbContext;

        [BindProperty(SupportsGet = true)]
        public List<ProductItem> Lista { get; set; }

        public string Search { get; set; }
        public string Sort { get; set; }

        public class ProductItem
        {
            public string Namn { get; set; }
            public string Bes { get; set; }
            public int Id { get; set; }
            public string BildSrc { get; set; }
        }

        public SearchResultModel(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void OnGet(string query, string sort)
        {
            Search = query;
            Sort = sort;
            var item = _dbContext.Products.Where(r => r.ProductName.Contains(query)
                                                      || r.Beskrivning.Contains(query)).Select(r => new ProductItem
            {
                Id = r.Id,
                Bes = r.Beskrivning,
                Namn = r.ProductName,
                BildSrc = r.BildSource
            });

            if (sort == "desc")
            {
                Sort = "asc";
                item = item.OrderByDescending(s => s.Namn);
            }
            else
            {
                Sort = "desc";
                item = item.OrderBy(s => s.Namn);
            }

            Lista = item.ToList();
        }

    }
}
