using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
        public ICollection<SalesInvoice> SalesInvoices { get; set; }
    }
}