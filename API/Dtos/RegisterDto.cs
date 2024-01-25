using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class RegisterDto
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    public string Name {get;set;}
    public string LastName {get;set;}
    public string Phone {get;set;}
    public DateOnly DateEntry {get;set;}
    public int IdAddress {get;set;}
    public int IdCompany {get;set;}
}
