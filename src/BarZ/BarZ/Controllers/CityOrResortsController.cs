using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarZ.Data;
using BarZ.Data.Models;

namespace BarZ.Controllers
{
    public class CityOrResortsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CityOrResortsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CityOrResorts
        public async Task<IActionResult> Index()
        {
            return View(await _context.CityOrResort.ToListAsync());
        }

        // GET: CityOrResorts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityOrResort = await _context.CityOrResort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityOrResort == null)
            {
                return NotFound();
            }

            return View(cityOrResort);
        }

        // GET: CityOrResorts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CityOrResorts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] CityOrResort cityOrResort)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cityOrResort);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cityOrResort);
        }

        // GET: CityOrResorts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityOrResort = await _context.CityOrResort.FindAsync(id);
            if (cityOrResort == null)
            {
                return NotFound();
            }
            return View(cityOrResort);
        }

        // POST: CityOrResorts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] CityOrResort cityOrResort)
        {
            if (id != cityOrResort.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityOrResort);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityOrResortExists(cityOrResort.Id))
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
            return View(cityOrResort);
        }

        // GET: CityOrResorts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityOrResort = await _context.CityOrResort
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cityOrResort == null)
            {
                return NotFound();
            }

            return View(cityOrResort);
        }

        // POST: CityOrResorts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityOrResort = await _context.CityOrResort.FindAsync(id);
            _context.CityOrResort.Remove(cityOrResort);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityOrResortExists(int id)
        {
            return _context.CityOrResort.Any(e => e.Id == id);
        }
    }
}
