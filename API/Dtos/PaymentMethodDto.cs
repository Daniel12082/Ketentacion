using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class PaymentMethodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}