using PaymentsList.BusinessLogic.Exceptions;
using PaymentsList.BusinessLogic.Interfaces;
using PaymentsList.BusinessLogic.Specifications;
using PaymentsList.DataAccess.Interfaces;
using PaymentsList.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Implementation
{
    public class ExpenceService : IExpenceService
    {
        private readonly IBaseRepository<ExpenceDatail> _repository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Group> _groupRepository;
        public ExpenceService(IBaseRepository<ExpenceDatail> repository, IBaseRepository<User> userRepository, IBaseRepository<Group> groupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<ExpenceDatail>> GetExpencesAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<ExpenceDatail> GetExpenceByIdAsync(int id)
        {
            var specification = new ExpenceByIdSpecification(id);
            var item = await _repository.GetSingleAsync(specification);

            return item;
        }

        public async Task CreateExpence(decimal amount, int userId, string description, int groupId)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            var group = await _groupRepository.GetByIdAsync(groupId);

            if (user == null) throw new UserNotFoundException();
            if (group == null) throw new GroupNotFoundException();

            var expenceHeader = new ExpenceHeader()
            {
                Descrption = description,
                User = user,
                Group = group
            };

            var expenceDetail = new ExpenceDatail()
            {
                Amount = amount,
                User = user,
                ExpenceHeader = expenceHeader
            };

            await _repository.InsertASync(expenceDetail);
        }
    }
}
