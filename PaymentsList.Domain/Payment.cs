using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.Domain
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Descripion { get; set; }
        public bool IsAccepted { get; set; }
        public User Issuer { get; set; }
        public User Recipient { get; set; }
        public Group Group { get; set; }
    }
}
