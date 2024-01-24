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
        Task<int> SaveAsync();
    }
}