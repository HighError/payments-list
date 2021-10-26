using PaymentsList.Domain;
using System.Collections.Generic;

namespace PaymentsList.API.DTO
{
    public class UserPostDTO
    {
        public string Name {  get; set; }
        public List<int> GroupsId {  get; set; }
    }
}
