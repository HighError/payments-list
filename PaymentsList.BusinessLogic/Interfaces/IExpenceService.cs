using PaymentsList.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Interfaces
{
    public interface IExpenceService
    {
        Task<IEnumerable<ExpenceDetail>> GetExpencesAsync();
        Task<ExpenceDetail> GetExpenceByIdAsync(int id);
        Task CreateExpence();
    }
}
