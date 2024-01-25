using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalesInvoice : BaseEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string Employee { get; set; }
        public DateTime Date { get; set; }
    }
}