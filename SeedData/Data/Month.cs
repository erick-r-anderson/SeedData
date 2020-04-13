using System;
using System.Collections.Generic;

namespace SeedData.Data
{
    public partial class Month
    {
        public Month()
        {
            SeedBloomMonth = new HashSet<Seed>();
            SeedBloomMonthEnd = new HashSet<Seed>();
            SeedEndMonth = new HashSet<Seed>();
            SeedStartMonth = new HashSet<Seed>();
        }

        public int Idmonth { get; set; }
        public string Month1 { get; set; }

        public ICollection<Seed> SeedBloomMonth { get; set; }
        public ICollection<Seed> SeedBloomMonthEnd { get; set; }
        public ICollection<Seed> SeedEndMonth { get; set; }
        public ICollection<Seed> SeedStartMonth { get; set; }
    }
}
