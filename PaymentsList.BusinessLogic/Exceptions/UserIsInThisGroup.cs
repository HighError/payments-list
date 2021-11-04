using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Exceptions
{
    internal class UserIsInThisGroup : BaseException
    {
        public UserIsInThisGroup() : base("User is in this group", HttpStatusCode.){ }
    }
}
