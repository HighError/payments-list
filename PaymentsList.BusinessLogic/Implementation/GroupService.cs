using PaymentsList.BusinessLogic.Interfaces;
using PaymentsList.DataAccess.Interfaces;
using PaymentsList.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IBaseRepository<Group> _repository;
        public GroupService(IBaseRepository<Group> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _repository.GetAsync();
        }
    }
}
