using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class RegisterDto
{
    public string FirstName {get;set;}
    public string LastName {get;set;}
    public string Username { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Phone { get; set; }
    public string Password { get; set; }
    public DateOnly DateEntry {get;set;}
    public int IdAddress { get; set; }
    public int IdCompany { get; set; }
}
