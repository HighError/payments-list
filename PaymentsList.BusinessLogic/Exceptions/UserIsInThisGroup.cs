using System.Net;

namespace PaymentsList.BusinessLogic.Exceptions
{
    internal class UserIsInThisGroup : BaseException
    {
        public UserIsInThisGroup() : base("User is in this group", HttpStatusCode.Conflict){ }
    }
}
