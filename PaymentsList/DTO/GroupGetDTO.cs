using PaymentsList.Domain;
using System.Collections.Generic;

namespace PaymentsList.API.DTO
{
    public class GroupGetDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<int> Users { get; set; }
    }
}
