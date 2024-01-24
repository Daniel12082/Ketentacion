using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public int DeparmentId { get; set; }
        public Department Deparment { get; set; }
        public ICollection<Address> Addresses { get; set; }

    }
}