using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Supplier : BaseEntity
    {
        public string Name { get; set; }
        public int TypeSupplierId { get; set; }
        public TypeSupplier TypeSupplier { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
    }
}