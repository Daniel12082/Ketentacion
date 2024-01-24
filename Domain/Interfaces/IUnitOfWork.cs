using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IRol Rols { get; }
        IUser Users { get; }
        IAddres Addresses { get;}
        ICategoryItem CategoryItems { get;}
        ICategoryProduct CategoryProducts { get;}
        ICity Cities { get;}
        IClient Clients { get;}
        ICompany Companies { get;}
        ICountry Countries { get;}
        IDepartment Departments { get;}
        IEvent Events { get;}
        IInvoice Invoices { get;}
        IItem Items { get;}
        INotification Notifications { get;}
        IOrder Orders { get;}
        IPaymentMethod PaymentMethods { get;}
        IProduct Products { get;}
        IProductItem ProductItems { get;}
        ISalesInvoice SalesInvoices { get;}
        ISupplier Suppliers { get;}
        ITypeSupplier TypeSuppliers { get;}
        Task<int> SaveAsync();
    }
}