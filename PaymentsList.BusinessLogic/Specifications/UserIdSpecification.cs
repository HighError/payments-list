using Ardalis.Specification;
using PaymentsList.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Specifications
{
    public class UserIdSpecification : Specification<User>
    {
        public UserIdSpecification(int id)
        {
            Query.Where(x => x.Id == id);
        }
    }
}
