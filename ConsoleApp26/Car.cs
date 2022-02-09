using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp26
{
    public partial class Car
    {
        public Car()
        {
            InverseCarNavigation = new HashSet<Car>();
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string Model { get; set; }
        public int MarkId { get; set; }
        public decimal Price { get; set; }
        public int? CarId { get; set; }
        public string Engine { get; set; }

        public virtual Car CarNavigation { get; set; }
        public virtual Mark Mark { get; set; }
        public virtual ICollection<Car> InverseCarNavigation { get; set; }
        public virtual ICollection<Sale> Sales { get; set; }
    }
}
