using PaymentsList.BusinessLogic.Exceptions;
using PaymentsList.BusinessLogic.Interfaces;
using PaymentsList.BusinessLogic.Specifications;
using PaymentsList.DataAccess.Interfaces;
using PaymentsList.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly IBaseRepository<Payment> _repository;
        private readonly IBaseRepository<User> _userRepository;
        private readonly IBaseRepository<Group> _groupRepository;
        public PaymentService(IBaseRepository<Payment> repository, IBaseRepository<User> userRepository, IBaseRepository<Group> groupRepository)
        {
            _repository = repository;
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }
        public async Task<IEnumerable<Payment>> GetPaymentsAsync()
        {
            return await _repository.GetAsync();
        }
        public async Task<Payment> GetPaymentByIdAsync(int id)
        {
            var specification = new PaymentSpecification(id);
            var item = await _repository.GetSingleAsync(specification);

            return item;
        }
        public async Task<IEnumerable<Payment>> GetPaymentsByIssuerAsync(int id)
        {
            var specification = new PaymentsByIssuerIdSpecification(id);
            var item = await _repository.GetAsync(specification);

            return item;
        }
        public async Task<IEnumerable<Payment>> GetPaymentsByRecipientAsync(int id)
        {
            var specification = new PaymentsByRecipientIdSpecification(id);
            var item = await _repository.GetAsync(specification);

            return item;
        }
        public async Task<IEnumerable<Payment>> GetPaymentsByGroupAsync(int id)
        {
            var specification = new PaymentsByGroupIdSpecification(id);
            var item = await _repository.GetAsync(specification);

            return item;
        }
        public async Task CreatePayment(decimal amount, string description, int issuerId, int recipientId, int groupId)
        {
            var issuer = await _userRepository.GetByIdAsync(issuerId);
            var recipient = await _userRepository.GetByIdAsync(recipientId);
            var group = await _groupRepository.GetByIdAsync(groupId);

            if (issuer == null || recipient == null) throw new UserNotFoundException();
            if (group == null) throw new GroupNotFoundException();

            var payment = new Payment()
            {
                Amount = amount,
                Descripion = description,
                Issuer = issuer,
                Recipient = recipient,
                Group = group,
                IsAccepted = false
            };

            await _repository.InsertASync(payment);
        }
        public async Task AcceptPayment(int id)
        {
            var payment = await GetPaymentByIdAsync(id);
            payment.IsAccepted = true;
            await _repository.UpdateAsync(payment);
        }
    }
}
