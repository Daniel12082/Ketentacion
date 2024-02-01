using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public int Nit { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Employee> Employees { get; set; }
    }
}