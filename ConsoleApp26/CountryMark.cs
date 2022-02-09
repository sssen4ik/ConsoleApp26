using System;
using System.Collections.Generic;

#nullable disable

namespace ConsoleApp26
{
    public partial class CountryMark
    {
        public int CountryId { get; set; }
        public int MarkId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Mark Mark { get; set; }
    }
}
