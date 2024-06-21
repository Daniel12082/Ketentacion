using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Routing.Patterns;

namespace API.Dtos
{
    public class RolDto
    {
        public int Id { get; set; } 
        public string Name { get; set; }
    }
}