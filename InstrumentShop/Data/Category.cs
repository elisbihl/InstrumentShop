using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstrumentShop.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public List<Products> Produkter { get; set; }
        public string CatImg { get; set; }
    }
}
