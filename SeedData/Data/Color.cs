using System;
using System.Collections.Generic;

namespace SeedData.Data
{
    public partial class Color
    {
        public Color()
        {
            SeedColor1 = new HashSet<Seed>();
            SeedColor2 = new HashSet<Seed>();
            SeedColor3 = new HashSet<Seed>();
        }

        public int Idcolor { get; set; }
        public string Color1 { get; set; }

        public ICollection<Seed> SeedColor1 { get; set; }
        public ICollection<Seed> SeedColor2 { get; set; }
        public ICollection<Seed> SeedColor3 { get; set; }
    }
}
