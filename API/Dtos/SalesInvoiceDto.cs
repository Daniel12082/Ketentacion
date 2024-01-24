using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class SalesInvoiceDto
    {
        public int Id { get; set; }
        public Order Order { get; set; }
        public string Employee { get; set; }
        public DateTime Date { get; set; }
    }
}