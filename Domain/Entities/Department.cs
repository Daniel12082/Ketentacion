using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Department : BaseEntity
    {
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country IdCountryFkNavigation  { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}