using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.BusinessLogic.Exceptions
{
    public class GroupNotFoundException : BaseException
    {
        public GroupNotFoundException() : base("Group not found", HttpStatusCode.NotFound) { }
    }
}
