using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Aplication.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrder
    {
        private readonly KetentacionBackendContext _context;

        public OrderRepository(KetentacionBackendContext context) : base(context)
        {
            _context = context;
        }
    }
}