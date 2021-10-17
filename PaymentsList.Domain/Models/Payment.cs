using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.Domain.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public int IssuerId { get; set; }
        public User Issuer { get; set; }
        public int RecipientId { get; set; }
        public User Recipient { get; set; }
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public bool IsAccepted {  get; set; }

    }
}
