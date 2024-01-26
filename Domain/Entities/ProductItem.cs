using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductItem : BaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public ICollection<Item> Items { get; set; }
        public int QuantityItem { get; set; }
    }
}