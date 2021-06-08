using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BarZ.Data;
using BarZ.Data.Models;

namespace BarZ.Areas.Bar_reviews.Controllers
{
    [Area("Bar-reviews")]
    public class FeaturesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeaturesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bar-reviews/Features
        public async Task<IActionResult> Index()
        {
            return View(await _context.Features.ToListAsync());
        }

        // GET: Bar-reviews/Features/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feature = await _context.Features
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // GET: Bar-reviews/Features/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bar-reviews/Features/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FeatureName,Selected")] Feature feature)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feature);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feature);
        }

        // GET: Bar-reviews/Features/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feature = await _context.Features.FindAsync(id);
            if (feature == null)
            {
                return NotFound();
            }
            return View(feature);
        }

        // POST: Bar-reviews/Features/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FeatureName,Selected")] Feature feature)
        {
            if (id != feature.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feature);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatureExists(feature.Id))
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
            return View(feature);
        }

        // GET: Bar-reviews/Features/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feature = await _context.Features
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        // POST: Bar-reviews/Features/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feature = await _context.Features.FindAsync(id);
            _context.Features.Remove(feature);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatureExists(int id)
        {
            return _context.Features.Any(e => e.Id == id);
        }
    }
}
