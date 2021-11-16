using System.Collections.Generic;

namespace PaymentsList.Domain
{
    public class ExpenceDetail
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenceHeader ExpenceHeader { get; set; }
        public User User { get; set; }
    }
}
