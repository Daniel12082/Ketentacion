using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int amount { get; set; }
        public int PaymentMethodId { get; set; }
    }
}