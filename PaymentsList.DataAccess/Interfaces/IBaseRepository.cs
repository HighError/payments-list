using Ardalis.Specification;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.DataAccess.Interfaces
{
    public interface IBaseRepository<T>
    {
        IUnitOfWork UnitOfWork { get; }
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAsync();
        Task<T> InsertASync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(int id);
        Task<T> GetAsync(ISpecification<T> specification);
        Task<IEnumerable<T>> GetSingleAsync(ISpecification<T> specification);
    }
}
