using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Aplication.Repository
{
    public class ProductItemRepository : GenericRepository<ProductItem>, IProductItem
    {
        private readonly KetentacionBackendContext _context;

        public ProductItemRepository(KetentacionBackendContext context) : base(context)
        {
            _context = context;
        }
    }
}