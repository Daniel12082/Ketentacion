using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace API.Dtos
{
    public class ProductItemDto
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int QuantityItem { get; set; }
    }
}