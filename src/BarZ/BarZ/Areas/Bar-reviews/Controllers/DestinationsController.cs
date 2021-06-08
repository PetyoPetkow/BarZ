namespace BarZ.Areas.Bar_reviews.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Services.Interfaces;
    using BarZ.Areas.Bar_reviews.Models.Destinations.BindingModels;

    public class DestinationsController : BarReviewsController
    {
        private readonly ApplicationDbContext _context;
        private readonly IDestinationsService destinationsService;

        public DestinationsController(ApplicationDbContext context, IDestinationsService destinationsService)
        {
            _context = context;
            this.destinationsService = destinationsService;
        }

        //GET: Destinations
        //public async Task<IActionResult> Index()
        //{
        //    return View(await _context.Destinations.ToListAsync());
        //}

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<IdNameViewModel> destinations = this.destinationsService.GetAll();

            DestinationsViewModel destinationsViewModel = new DestinationsViewModel();

            destinationsViewModel.Destinations = destinations;
           

            return this.View(destinationsViewModel);
        }

        // GET: Destinations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destinations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // GET: Destinations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Destinations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description")] Destination destination)
        {
            if (ModelState.IsValid)
            {
                _context.Add(destination);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(destination);
        }

        // GET: Destinations/Edit/5
        
        public IActionResult Update(int id)
        {
            DestinationUpdateBindingModel destination = this.destinationsService.GetByIdForUpdateMethod(id);
            
            bool isDestinationNull = destination == null;  
            if (isDestinationNull)
            {
                return this.RedirectToAction("index");
            }

            return this.View(destination);
        }

        // POST: Destinations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(DestinationUpdateBindingModel model)
        {
            bool isUpdated = await this.destinationsService.UpdateAsync(model);
            if (isUpdated == false)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction("index");
        }

        // GET: Destinations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination = await _context.Destinations
                .FirstOrDefaultAsync(m => m.Id == id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        // POST: Destinations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var destination = await _context.Destinations.FindAsync(id);
            _context.Destinations.Remove(destination);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DestinationExists(int id)
        {
            return _context.Destinations.Any(e => e.Id == id);
        }
    }
}
