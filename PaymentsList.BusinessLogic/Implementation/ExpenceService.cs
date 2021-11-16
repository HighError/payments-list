using PaymentsList.BusinessLogic.Exceptions;
using PaymentsList.BusinessLogic.Interfaces;
using PaymentsList.BusinessLogic.Specifications;
using PaymentsList.DataAccess.Interfaces;
using PaymentsList.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Implementation
{
    public class ExpenceService : IExpenceService
    {
        private readonly IBaseRepository<ExpenceHeader> _repository;
        public ExpenceService(IBaseRepository<ExpenceHeader> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<ExpenceHeader>> GetExpencesAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<ExpenceHeader> GetExpenceByIdAsync(int id)
        {
            var specification = new ExpenceByIdSpecification(id);
            var item = await _repository.GetSingleAsync(specification);

            return item;
        }

        public async Task CreateExpence(ExpenceHeader expenceHeader)
        {
            await _repository.InsertASync(expenceHeader);
            await _repository.UnitOfWork.CommitAsync();
        }
    }
}
