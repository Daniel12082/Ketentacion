using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class AddressDto
    {
        public int Id { get; set; }
        public string Career { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string complement { get; set; }
        public int CityId { get; set; }
        public ICollection<User> Users { get; set; }
    }
}