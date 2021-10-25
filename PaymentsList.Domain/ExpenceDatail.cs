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
        public int Amount { get; set; }
        public int ExpenceHeaderId { get; set; }
        public ExpenceHeader ExpenceHeader { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
