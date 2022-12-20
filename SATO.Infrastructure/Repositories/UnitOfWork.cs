using Microsoft.EntityFrameworkCore;
using SATO.Entities.Entities;
using SATO.Infrastructure.Interfaces;
using SATO.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Infrastructure.Repositories
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : SatoDbContext
    {
        private Dictionary<(Type type, string name), object> _repositories;
        private readonly TContext _context;

        public UnitOfWork(TContext context)
        {
            _context = context;
        }

        internal DbSet<TContext> _dbSet { get; set; }
        public async Task<bool> CommitAsync()
        {
            try
            {
                var a = await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {

            }
            
            return await _context.SaveChangesAsync() > 0;
        }
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        internal object GetOrAddRepository(Type type, object repo) 
        {
            if (_repositories == null) _repositories = new Dictionary<(Type type, string Name), object>();

            if (_repositories.TryGetValue((type, repo.GetType().FullName), out var repository)) return repository;
            _repositories.Add((type, repo.GetType().FullName), repo);
            return repo;
        }
        public GenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            return (GenericRepository<TEntity>)GetOrAddRepository(typeof(TEntity), new GenericRepository<TEntity>(_context));
        }
    }
}
