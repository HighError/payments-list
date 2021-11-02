using PaymentsList.BusinessLogic.Interfaces;
using PaymentsList.DataAccess.Interfaces;
using PaymentsList.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Implementation
{
    public class UserService : IUserService
    {
        private readonly IBaseRepository<User> _repository;
        public UserService(IBaseRepository<User> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _repository.GetAsync();
        }
    }
}
