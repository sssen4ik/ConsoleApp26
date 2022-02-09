using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp26
{
    public partial class Worker
    {
        public Worker()
        {
            Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}
