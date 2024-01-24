using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Aplication.Repository;
public class RolRepository : GenericRepository<Rol>, IRol
{
    private readonly KetentacionBackendContext _context;

    public RolRepository(KetentacionBackendContext context) : base(context)
    {
        _context = context;
    }
}