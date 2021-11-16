﻿using System.Collections.Generic;

namespace PaymentsList.Domain
{
    public class ExpenceHeader
    {
        public int Id { get; set; }
        public string Descrption { get; set; }
        public List<ExpenceDetail> ExpenceDetails { get; set; }
        public User User { get; set; }
        public Group Group { get; set; }
    }
}
