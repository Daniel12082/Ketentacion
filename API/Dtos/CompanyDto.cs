using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class CompanyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Nit { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int AddressId { get; set; }
    }
}