using Ardalis.Specification;
using PaymentsList.Domain;

namespace PaymentsList.BusinessLogic.Specifications
{
    public class PaymentsByRecipientIdSpecification : Specification<Payment>
    {
        public PaymentsByRecipientIdSpecification(int id)
        {
            Query.Include(x => x.Recipient.Id == id);
        }
    }
}
