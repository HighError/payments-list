using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException() : base("User not found!", HttpStatusCode.NotFound) { }
    }
}
 