using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedData.Data
{
    public partial class Height
    {
        public Height()
        {
            GrowthHeight = new HashSet<Seed>();
        }
        public int? IdHeight { get; set; }
        public string HeightValue { get; set; }

        public ICollection<Seed> GrowthHeight { get; set; }
    }
}
