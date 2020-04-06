using System;
using System.Collections.Generic;

namespace SeedData.Data
{
    public partial class Color
    {
        public Color()
        {
            Seed = new HashSet<Seed>();
        }

        public int Idcolor { get; set; }
        public string Color1 { get; set; }

        public ICollection<Seed> Seed { get; set; }
    }
}
