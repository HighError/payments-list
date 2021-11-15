using Ardalis.Specification;
using PaymentsList.Domain;
using System.Linq;

namespace PaymentsList.BusinessLogic.Specifications
{
    public class ExpenceByIdSpecification : Specification<ExpenceDetail>
    {
        public ExpenceByIdSpecification(int id)
        {
            Query.Where(x => x.Id == id)
                .Include(y => y.ExpenceHeader);
        }
    }
}
