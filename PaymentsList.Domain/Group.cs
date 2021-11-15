using PaymentsList.Domain.Interfaces;
using System.Collections.Generic;

namespace PaymentsList.Domain
{
    public class Group : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> User { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
