using System.Net;

namespace PaymentsList.BusinessLogic.Exceptions
{
    public class UserNotFoundException : BaseException
    {
        public UserNotFoundException() : base("User not found!", HttpStatusCode.NotFound) { }
    }
}
 