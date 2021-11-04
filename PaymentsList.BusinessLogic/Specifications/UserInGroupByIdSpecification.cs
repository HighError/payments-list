using Ardalis.Specification;
using PaymentsList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Specifications
{
    public class UserInGroupByIdSpecification : Specification<Group>
    {
        public UserInGroupByIdSpecification(int groupId)
        {
            Query.Where(x => x.Id == groupId)
                .Include(y => y.User);
        }
    }
}
