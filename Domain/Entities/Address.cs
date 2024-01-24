using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Address : BaseEntity
    {
        public string Career { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string complement { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Client> Clients { get; set; }
        public ICollection<Supplier> Suppliers { get; set; }
        public ICollection<Company> Companies { get; set; }
    }
}