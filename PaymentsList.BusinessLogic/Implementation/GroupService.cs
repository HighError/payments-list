using PaymentsList.BusinessLogic.Exceptions;
using PaymentsList.BusinessLogic.Interfaces;
using PaymentsList.BusinessLogic.Specifications;
using PaymentsList.DataAccess.Interfaces;
using PaymentsList.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace PaymentsList.BusinessLogic.Implementation
{
    public class GroupService : IGroupService
    {
        private readonly IBaseRepository<Group> _repository;
        private readonly IBaseRepository<User> _userRepository;
        public GroupService(IBaseRepository<Group> repository, IBaseRepository<User> userReoisitory)
        {
            _repository = repository;
            _userRepository = userReoisitory;
        }

        public async Task AddUserToGroupAsync(int groupId, int userId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var group = await _repository.GetByIdAsync(groupId);
            if (user == null)
            {
                throw new UserNotFoundException();
            }
            var specification = new UserInGroupByIdSpecification(groupId);
            var usersInGroup = await _repository.GetSingleAsync(specification);

            if (!usersInGroup.User.Any(x => x.Id == userId))
            {
                throw new UserIsInThisGroup();
            }
            group.User.Add(user);
            await _repository.UpdateAsync(group);
            await _repository.UnitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _repository.GetAsync();
        }
    }
}
