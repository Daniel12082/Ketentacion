using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Order : BaseEntity
    {
        public int amount { get; set; }
        public ICollection<ProductItem> ProductItems { get; set; }
        public ICollection<Invoice> Invoices { get; set; }
        public ICollection<SalesInvoice> SalesInvoices { get; set; }
        public int PaymentMethodId { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}