using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class InvoiceDto
    {
        public int OrderId { get; set; }
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
    }
}