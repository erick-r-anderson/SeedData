using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SeedData.Data;
using SeedData.Models;

namespace SeedData
{
    public class Program
    {
        public static void Main(string[] args)
        {

           PopulateData();
            //UpdateMonths();

            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
        
       /* public static void UpdateMonths()
        {
            var _context = new SeedContext();
            
            foreach (Seed s in _context.Seeds)
            {
                s.Start = "January";
                s.End = "January";
                _context.SaveChanges();
            }
        }
*/
        public static void PopulateData()
        {
            var _context = new seedsContext();

            using (var reader = new StreamReader("Seeds.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<SeedMap>();
                var records = csv.GetRecords<Seed>();

                foreach (Seed s in records)
                {
                    s.SetProperties();
                    _context.Seed.Add(s);

                }

                _context.SaveChanges();
            }
        }
    }
}
