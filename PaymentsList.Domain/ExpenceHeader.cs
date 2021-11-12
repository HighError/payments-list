using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentsList.Domain
{
    public class ExpenceHeader
    {
        public int Id { get; set; }
        public string Descrption { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
