using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SeedData.Data;
using SeedData.Models;

namespace SeedData.Controllers
{
    public class SeedsController : Controller
    {
        private readonly seedsContext _context;

        public SeedsController(seedsContext context)
        {
            _context = context;
        }

        // GET: Seeds
        public async Task<IActionResult> Index(string SearchString, int? pageNumber, string currentFilter)
        {
            var seedsContext = _context.Seed.Include(s => s.BloomMonth).Include(s => s.BloomMonthEnd).Include(s => s.Color1).Include(s => s.Color2).Include(s => s.Color3)
                .Include(s => s.EndMonth).Include(s => s.StartMonth);
            IQueryable<Seed> displaySeeds;
                    
           
            if (SearchString != null)
            {

                displaySeeds = seedsContext.Where(s => (s.CommonName.ToUpper().Contains(SearchString.ToUpper()) ||
                 s.ScientificName.ToUpper().Contains(SearchString.ToUpper()) ||
                 s.Color1.Color1.ToUpper().Contains(SearchString.ToUpper()) ||
                 s.BloomMonth.Month1.ToUpper().Contains(SearchString.ToUpper()) ||
                 s.StartMonth.Month1.ToUpper().Contains(SearchString.ToUpper()) ||
                 s.EndMonth.Month1.ToUpper().Contains(SearchString.ToUpper())));
                    
            }
            else
            {
                displaySeeds = seedsContext;
            }

            displaySeeds = displaySeeds.OrderBy(s => s.ScientificName);

            ViewBag.DisplaySeeds = displaySeeds.ToList();

            
            return View(await displaySeeds.ToListAsync());
            
        }

        // GET: Seeds/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seed
                .Include(s => s.BloomMonth)
                .Include(s => s.Color1)
                .Include(s => s.EndMonth)
                .Include(s => s.StartMonth)
                .FirstOrDefaultAsync(m => m.SeedId == id);
            if (seed == null)
            {
                return NotFound();
            }

            return View(seed);
        }

        // GET: Seeds/Create
        public IActionResult Create()
        {
            
            ViewData["BloomMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1");
            ViewData["ColorId"] = new SelectList(_context.Color, "Idcolor", "Color1");
            ViewData["EndMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1");
            ViewData["StartMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1");
            return View();
        }

        // POST: Seeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeedId,ScientificName,CommonName,DisplayPrairie,DisplaySavanna,DisplayWoodland,DisplayDry,DisplayDryMesic,DisplayMesic,DisplayWetMesic,DisplayWet,ColorId,StartMonthId,EndMonthId,BloomMonthId")] Seed seed)
        {
            if (ModelState.IsValid)
            {
                _context.Add(seed);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            //DisplayData["BloomMonthId"] = new SelectList(_context.Month, "Idmonth", "Idmonth", seed.BloomMonthId);
            ViewData["BloomMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1", seed.BloomMonth);
            ViewData["ColorId"] = new SelectList(_context.Color, "Idcolor", "Color1", seed.Color1Id);
            ViewData["EndMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1", seed.EndMonthId);
            ViewData["StartMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1", seed.StartMonthId);
            return View(seed);
        }

        // GET: Seeds/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seed.FindAsync(id);
            if (seed == null)
            {
                return NotFound();
            }
            ViewData["BloomMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1");
            ViewData["ColorId"] = new SelectList(_context.Color, "Idcolor", "Color1");
            ViewData["EndMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1");
            ViewData["StartMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1");
            return View(seed);
        }

        // POST: Seeds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeedId,ScientificName,CommonName,DisplayPrairie,DisplaySavanna,DisplayWoodland,DisplayDry,DisplayDryMesic,DisplayMesic,DisplayWetMesic,DisplayWet,Color1Id, Color2Id, Color3Id, StartMonthId,EndMonthId,BloomMonthId, BloomMonthEndId")] Seed seed)
        {
            if (id != seed.SeedId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(seed);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeedExists(seed.SeedId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BloomMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1", seed.BloomMonth);
            ViewData["ColorId"] = new SelectList(_context.Color, "Idcolor", "Color1", seed.Color1Id);
            ViewData["EndMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1", seed.EndMonthId);
            ViewData["StartMonthId"] = new SelectList(_context.Month, "Idmonth", "Month1", seed.StartMonthId);
            return View(seed);
            
        }

        // GET: Seeds/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var seed = await _context.Seed
                .Include(s => s.BloomMonth)
                .Include(s => s.Color1)
                .Include(s => s.EndMonth)
                .Include(s => s.StartMonth)
                .FirstOrDefaultAsync(m => m.SeedId == id);
            if (seed == null)
            {
                return NotFound();
            }

            return View(seed);
        }

        // POST: Seeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seed = await _context.Seed.FindAsync(id);
            _context.Seed.Remove(seed);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeedExists(int id)
        {
            return _context.Seed.Any(e => e.SeedId == id);
        }

        [HttpGet, ActionName("ExportCSV")]
        public async Task<IActionResult> ExportCSV(List<Seed> inputList)
        {
            var fileName = "SeedData.csv";
            var displayList = inputList.ToList();

            using (var writer = new StreamWriter(fileName))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<SeedMap>();
                csv.WriteRecords(displayList);
            }

            var memory = new MemoryStream();
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            //return RedirectToAction(nameof(Index));
            return File(memory, MediaTypeNames.Application.Octet, WebUtility.HtmlEncode(fileName));

        }
    }
}
