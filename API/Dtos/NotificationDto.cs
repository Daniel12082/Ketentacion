using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.AspNetCore.Routing.Patterns;

namespace API.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; } 
        public string Message { get; set; }
        public string Description { get; set; }
    }
}