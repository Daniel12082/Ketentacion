using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Aplication.Repository
{
    public class CategoryItemRepository : GenericRepository<CategoryItem>, ICategoryItem
    {
        private readonly KetentacionBackendContext _context;

        public CategoryItemRepository(KetentacionBackendContext context) : base(context)
        {
            _context = context;
        }
    }
}