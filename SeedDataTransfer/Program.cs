using CsvHelper;
using SeedData;
using SeedData.Models;
using System;
using System.Globalization;
using System.IO;

namespace SeedDataTransfer
{
    class Program
    {
        static void Main(string[] args)
        {
           /* var _context = new SeedContext();

            using (var reader = new StreamReader("C:\\Users\\erick\\source\\repos\\SeedData\\SeedDataTransfer\\Seeds.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<SeedMap>();
                var records = csv.GetRecords<Seed>();

                foreach (Seed s in records)
                {
                    s.SetProperties();
                    _context.Seeds.Add(s);
                    
                }

                _context.SaveChanges();
            }*/

            
        }
    }
}
