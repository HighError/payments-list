using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.Domain
{
    public class ExpenceDatail
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public ExpenceHeader ExpenceHeader { get; set; }
        public User User { get; set; }
    }
}
