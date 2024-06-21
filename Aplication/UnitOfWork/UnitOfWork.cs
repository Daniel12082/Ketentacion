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
        private ICategoryItem _categoryitems;
        private ICategoryProduct _categoryproducts;
        private ICity _cities;
        private IClient _clients;
        private ICompany _companies;
        private ICountry _countries;
        private IDepartment _departments;
        private IEvent _events;
        private IItem _items;
        private INotification _notifications;
        private IInvoice _invoices;
        private IOrder _orders;
        private IPaymentMethod _paymentmethods;
        private IProduct _products;
        private IRol _rols;
        private IProductItem _productitems;
        private ISalesInvoice _salesinvoices;
        private ISupplier _suppliers;
        private ITypeSupplier _typesuppliers;

        public IRol Roles
        {
            get
            {
                if (_rols == null)
                {
                    _rols = new RolRepository(_context);
                }
                return _rols;
            }
        }
        public IAddres Addresses
        {
            get
            {
                if (_addresses == null)
                {
                    _addresses = new AddressRepository(_context);
                }
                return _addresses;
            }
        }
        public ICategoryItem CategoryItems
        {
            get
            {
                if (_categoryitems == null)
                {
                    _categoryitems = new CategoryItemRepository(_context);
                }
                return _categoryitems;
            }
        }
        public ICategoryProduct CategoryProducts
        {
            get
            {
                if (_categoryproducts == null)
                {
                    _categoryproducts = new CategoryProductRepository(_context);
                }
                return _categoryproducts;
            }
        }
        public ICity Cities
        {
            get
            {
                if (_cities == null)
                {
                    _cities = new CityRepository(_context);
                }
                return _cities;
            }
        }
        public IClient Clients
        {
            get
            {
                if (_clients == null)
                {
                    _clients = new ClientRepository(_context);
                }
                return _clients;
            }
        }
        public ICompany Companies
        {
            get
            {
                if (_companies == null)
                {
                    _companies = new CompanyRepository(_context);
                }
                return _companies;
            }
        }
        public ICountry Countries
        {
            get
            {
                if (_countries == null)
                {
                    _countries = new CountryRepository(_context);
                }
                return _countries;
            }
        }
        public IDepartment Departments
        {
            get
            {
                if (_departments == null)
                {
                    _departments = new DepartmentRepository(_context);
                }
                return _departments;
            }
        }
        public IEvent Events
        {
            get
            {
                if (_events == null)
                {
                    _events = new EventRepository(_context);
                }
                return _events;
            }
        }
        public IInvoice Invoices
        {
            get
            {
                if (_invoices == null)
                {
                    _invoices = new InvoiceRepository(_context);
                }
                return _invoices;
            }
        }
        public IItem Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new ItemRepository(_context);
                }
                return _items;
            }
        }
        public INotification Notifications
        {
            get
            {
                if (_notifications == null)
                {
                    _notifications = new NotificationRepository(_context);
                }
                return _notifications;
            }
        }
        public IOrder Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new OrderRepository(_context);
                }
                return _orders;
            }
        }
        public IPaymentMethod PaymentMethods
        {
            get
            {
                if (_paymentmethods == null)
                {
                    _paymentmethods = new PaymentMethodRepository(_context);
                }
                return _paymentmethods;
            }
        }
        public IProduct Products
        {
            get
            {
                if (_products == null)
                {
                    _products = new ProductRepository(_context);
                }
                return _products;
            }
        }
        public IProductItem ProductItems
        {
            get
            {
                if (_productitems == null)
                {
                    _productitems = new ProductItemRepository(_context);
                }
                return _productitems;
            }
        }
        public ISalesInvoice SalesInvoices
        {
            get
            {
                if (_salesinvoices == null)
                {
                    _salesinvoices = new SalesInvoiceRepository(_context);
                }
                return _salesinvoices;
            }
        }
        public ISupplier Suppliers
        {
            get
            {
                if (_suppliers == null)
                {
                    _suppliers = new SupplierRepository(_context);
                }
                return _suppliers;
            }
        }
        public ITypeSupplier TypeSuppliers
        {
            get
            {
                if (_typesuppliers == null)
                {
                    _typesuppliers = new TypeSupplierRepository(_context);
                }
                return _typesuppliers;
            }
        }

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