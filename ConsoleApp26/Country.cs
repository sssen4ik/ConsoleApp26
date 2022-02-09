using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp26
{
    public partial class Country
    {
        public Country()
        {
            CountryMarks = new HashSet<CountryMark>();
        }

        public int Id { get; set; }
        public string CountryName { get; set; }

        public virtual ICollection<CountryMark> CountryMarks { get; set; }
    }
}
