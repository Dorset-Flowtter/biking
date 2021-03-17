using DublinBike.Models;
using DublinBike.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DublinBike.Controllers
{
    public class BikeController : Controller
    {
        private readonly MvcBikeContext _context;

        public BikeController(MvcBikeContext context)
        {
            _context = context;
        }

        // GET: Bikes
        public async Task<IActionResult> Index(string searchString)
        {
            var bikes = from currentBikeItem in _context.Bike select currentBikeItem;

            if (!String.IsNullOrEmpty(searchString))
            {
                bikes = bikes.Where(s => s.Name.Contains(searchString));
            }

            return View(await bikes.ToListAsync());
        }

        // GET: Bike/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .FirstOrDefaultAsync(m => m.Number == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Bike/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,ContractName,Name,Address,Latitude,Longitude,Banking,AvailableBikes,AvailableStands,Capacity,Status")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bike);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }


        private bool BikeExists(int id)
        {
            return _context.Bike.Any(e => e.Number == id);
        }

        // GET: Bike/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike.FindAsync(id);
            if (bike == null)
            {
                return NotFound();
            }
            return View(bike);
        }

        // POST: Bike/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Number,ContractName,Name,Address,Latitude,Longitude,Banking,AvailableBikes,AvailableStands,Capacity,Status")] Bike bike)
        {
            Console.WriteLine("yo les man");
            Console.WriteLine(id);
            Console.WriteLine(bike.Number);
            if (id != bike.Number)
            {
                return NotFound();
            }

            Console.WriteLine("tes");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bike);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bike.Number))
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
            return View(bike);
        }

        // GET: Movies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = await _context.Bike
                .FirstOrDefaultAsync(m => m.Number == id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: Movies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bike = await _context.Bike.FindAsync(id);
            _context.Bike.Remove(bike);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}