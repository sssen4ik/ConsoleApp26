using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp26
{
    public partial class Mark
    {
        public Mark()
        {
            Cars = new HashSet<Car>();
            CountryMarks = new HashSet<CountryMark>();
        }

        public int Id { get; set; }
        public string MarkName { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<CountryMark> CountryMarks { get; set; }
    }
}
