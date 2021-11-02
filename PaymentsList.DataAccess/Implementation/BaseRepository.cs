using Ardalis.Specification;
using Microsoft.EntityFrameworkCore;
using PaymentsList.DataAccess.Interfaces;
using PaymentsList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.DataAccess.Implementation
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IEntity
    {
        private readonly PaymentListDBContext _context;

        public IUnitOfWork UnitOfWork => _context;

        public BaseRepository(PaymentListDBContext context)
        {
            _context = context;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>()
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAsync()
        {
            return await _context.Set<T>()
                .ToListAsync();
        }

        public async Task<T> InsertASync(T item)
        {
            var inserted = await _context.AddAsync(item);
            return inserted.Entity;
        }

        public Task UpdateAsync(T item)
        {
            _context.Entry(item).State = EntityState.Modified;
            return Task.CompletedTask;
        }
        public async Task DeleteAsync(int id)
        {
            var item = await _context.Set<T>().FirstAsync(x => x.Id == id);
            _context.Remove(item);
        }

        public async Task<T> GetAsync(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetSingleAsync(ISpecification<T> specification)
        {
            throw new NotImplementedException();
        }
    }
}
