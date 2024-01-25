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
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<CategoryItem> CategoryItems { get; set; }
    public DbSet<CategoryProduct> CategoryProducts { get; set; }
    public DbSet<City> Cities { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductItem> ProductItems { get; set; }
    public DbSet<SalesInvoice> SalesInvoices { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }
    public DbSet<TypeSupplier> TypeSuppliers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}