using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Persistence.Data;
public class KetentacionBackendContext : DbContext
{
    public KetentacionBackendContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<UserRol> UsersRols { get; set; }
    public DbSet<Rol> Rols { get; set; }
    public DbSet<RefreshToken> RefreshTokens { get; set; }
    public DbSet<Address> Address { get; set; }
    public DbSet<Company> Company { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}