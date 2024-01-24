using Aplication.Repository;
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