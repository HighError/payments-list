using PaymentsList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Interfaces
{
    public interface IExpenceService
    {
        Task<IEnumerable<ExpenceDatail>> GetExpencesAsync();
        Task<ExpenceDatail> GetExpenceByIdAsync(int id);
        Task CreateExpence(decimal amount, int userId, string description, int groupId);
    }
}
