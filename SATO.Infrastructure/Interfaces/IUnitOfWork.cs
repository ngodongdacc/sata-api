using Microsoft.EntityFrameworkCore;
using SATO.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Infrastructure.Interfaces
{
    public interface IUnitOfWork<TContext> : IDisposable where TContext : DbContext
    {
        Task<bool> CommitAsync();
        void Commit();
        void Dispose();
        GenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
    }
}
