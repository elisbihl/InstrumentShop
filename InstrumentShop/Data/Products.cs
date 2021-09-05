using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.Language.Extensions;

namespace InstrumentShop.Data
{
    public class Products
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Pris { get; set; }
        public Category Kategori { get; set; }
        public string Beskrivning { get; set; }
        public string BildSource { get; set; }
        public DateTime LastModified { get; set; }
    }
}
