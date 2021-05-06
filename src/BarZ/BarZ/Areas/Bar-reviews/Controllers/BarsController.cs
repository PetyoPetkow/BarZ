namespace BarZ.Areas.Bar_reviews.Controllers 
{ 
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.EntityFrameworkCore;
    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Areas.Bar_reviews.Controllers;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
    using BarZ.Services;
    using BarZ.Services.Interfaces;
    using System.Collections.Generic;
    using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
    using Microsoft.AspNetCore.Hosting;

    public class BarsController : BarReviewsController
    {
        private readonly IBarsService barsService;
        private readonly IImageService imageService;
        private readonly IWebHostEnvironment webHost;
        private readonly ApplicationDbContext _context;

        public BarsController(ApplicationDbContext context, IBarsService barsService, IImageService imageService, IWebHostEnvironment webHost)
        {
            _context = context;
            this.barsService = barsService;
            this.imageService = imageService;
            this.webHost = webHost;
        }

        // GET: Bars
        public async Task<IActionResult> Index()
        {
            IEnumerable<BarViewModel> bars = this.barsService.GetAll();

            return this.View(bars);
        }

        // GET: Bars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            BarViewModel bar = this.barsService.GetById(id);

            bool isNull = bar == null;
            
            if (isNull)
            {
                return this.BadRequest();
            }

            return this.View(bar);
        }

        // GET: Bars/Create
        public IActionResult Create()
        {
            ViewData["DestinationId"] = new SelectList(_context.Destinations, "Id", "Name");
            return View();
        }

        // POST: Bars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BarCreateBindingModel bar)
        {
            await this.barsService.CreateAsync(bar, webHost.WebRootPath);

            return this.RedirectToAction("index");
        }

        // GET: Bars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bar = await _context.Bars.FindAsync(id);
            if (bar == null)
            {
                return NotFound();
            }
            ViewData["DestinationId"] = new SelectList(_context.Destinations, "Id", "Name", bar.DestinationId);
            return View(bar);
        }

        // POST: Bars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,BeginningOfTheWorkDay,EndOfTheWorkDay,Description,FacebookPageUrl,DestinationId")] Bar bar)
        {
            if (id != bar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarExists(bar.Id))
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
            ViewData["DestinationId"] = new SelectList(_context.Destinations, "Id", "Name", bar.DestinationId);
            return View(bar);
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.barsService.DeleteAsync(id);

            return this.RedirectToAction("index");
        }

        // GET: Bars/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var bar = await _context.Bars
        //        .Include(b => b.Destination)
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (bar == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(bar);
        //}

        // POST: Bars/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var bar = await _context.Bars.FindAsync(id);
        //    _context.Bars.Remove(bar);

        //    await this.barsService.DeleteAsync(bar, webHost.WebRootPath);

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool BarExists(int id)
        {
            return _context.Bars.Any(e => e.Id == id);
        }
    }
}
