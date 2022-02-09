using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp26
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int CostumerId { get; set; }
        public int WorkerId { get; set; }
        public int CarId { get; set; }
        public DateTime DateOfSale { get; set; }
        public int? CustomerId { get; set; }

        public virtual Car Car { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
