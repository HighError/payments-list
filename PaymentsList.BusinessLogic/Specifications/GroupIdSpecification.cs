using Ardalis.Specification;
using PaymentsList.Domain;
using System.Linq;

namespace PaymentsList.BusinessLogic.Specifications
{
    public class GroupIdSpecification : Specification<Group>
    {
        public GroupIdSpecification(int id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}
