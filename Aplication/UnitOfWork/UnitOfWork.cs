using Aplication.Repository;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace APP.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
    
        private readonly KetentacionBackendContext _context;

        public UnitOfWork(KetentacionBackendContext context)
        {
            _context = context;
        }

        private IAddres _addresses;
        private ICategoryItem _categoriesitems;
        private ICategoryProduct _categoriesproducts;
        private ICity _cities;
        private IClient _clients;
        private ICompany _companys;
        private ICountry _countries;
        private IDepartment _departments;
        private IEvent _events;
        private IItem _items;
        private INotification _notifications;
        private IInvoice _invoices;
        private IOrder _ordes;
        private IPaymentMethod _paymentsmethods;
        private IProduct _products;
        private IProductItem _productsitems;
        private ISalesInvoice _salesinvoices;
        private ISupplier _suppliers;
        private ITypeSupplier _typessuppliers;

        private RolRepository _rol; 
        public IRol Rols
        {
            get
            {
                if (_rol == null)
                {
                    _rol = new RolRepository(_context);
                }
                return _rol;
            }
        }
         private UserRepository _user;
        public IUser Users
        {
            get
            {
                if (_user == null)
                {
                    _user = new UserRepository(_context);
                }
                return _user;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}