using CsvHelper.Configuration;
using SeedData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeedData.Models
{
   public class SeedMap : ClassMap<Seed>
    {
        public SeedMap()
        {
            Map(m => m.ScientificName).Name("Species");
            Map(m => m.CommonName).Name("Common Name");
            Map(m => m.SunExposure).Name("Sun Exposure");
            Map(m => m.Moisture).Name("Moisture");

        }
    }
}
