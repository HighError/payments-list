using System.Collections.Generic;

namespace PaymentsList.API.DTO
{
    public class GroupPostDTO
    {
        public string Name {  get; set; }
        public List<int> UserId {  get; set; }
    }
}
