using PaymentsList.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
    }
}
