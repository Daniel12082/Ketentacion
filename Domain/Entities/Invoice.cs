using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Invoice : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
    }
}