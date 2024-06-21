using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateOnly DateEntry { get; set; }
        public DateOnly DateDeparture { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int AddressId { get; set; } // Esta es la clave foránea
        public Address IdAddresFkNavigation { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Rol> Rols { get; set; } = new HashSet<Rol>();
        public ICollection<RefreshToken> RefreshTokens { get; set; } = new HashSet<RefreshToken>();
        public int IdCompany { get; set; }
        public Company Company { get; set; }
        public ICollection<UserRol> UsersRols { get; set; }
    }
}