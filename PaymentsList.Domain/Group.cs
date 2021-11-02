using PaymentsList.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
