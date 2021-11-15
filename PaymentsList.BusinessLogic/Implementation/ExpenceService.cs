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
        private readonly IBaseRepository<ExpenceDetail> _repository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Group> _groupRepository;
        public ExpenceService(IBaseRepository<ExpenceDetail> repository, IBaseRepository<User> userRepository, IBaseRepository<Group> groupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<ExpenceDetail>> GetExpencesAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<ExpenceDetail> GetExpenceByIdAsync(int id)
        {
            var specification = new ExpenceByIdSpecification(id);
            var item = await _repository.GetSingleAsync(specification);

            return item;
        }

        public async Task CreateExpence(/*ExpenceHeader expenceHeader, List<ExpenceDetail> expenceDatails*/)
        {
            //foreach (var item in expenceDatails)
            //{
            //    item.ExpenceHeader = expenceHeader;
            //    await _repository.InsertASync(item);
            //}
        }

        /*public async Task CreateExpence(decimal amount, int userId, string description, int groupId)
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
        }*/
    }
}
