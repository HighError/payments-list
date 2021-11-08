using PaymentsList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Interfaces
{
    public interface IPaymentService
    {
        Task<IEnumerable<Payment>> GetPaymentsAsync();
        Task<Payment> GetPaymentByIdAsync(int id);
        Task<IEnumerable<Payment>> GetPaymentsByIssuerAsync(int id);
        Task<IEnumerable<Payment>> GetPaymentsByRecipientAsync(int id);
        Task<IEnumerable<Payment>> GetPaymentsByGroupAsync(int id);
    }
}
