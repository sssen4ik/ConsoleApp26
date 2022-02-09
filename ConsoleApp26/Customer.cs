using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp26
{
    public partial class Customer
    {
        public Customer()
        {
            InverseCustomerNavigation = new HashSet<Customer>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int? CustomerId { get; set; }

        public virtual Customer CustomerNavigation { get; set; }
        public virtual ICollection<Customer> InverseCustomerNavigation { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
