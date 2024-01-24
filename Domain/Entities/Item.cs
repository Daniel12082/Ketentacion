using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Item : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
        public int Stock { get; set; }
        public int SupplierId { get; set; }
        public Supplier Supplier { get; set;}
        public int CategoryId { get; set; }
        public CategoryItem Category { get; set; }

    }
}