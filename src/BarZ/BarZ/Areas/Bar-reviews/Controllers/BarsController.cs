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
    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;

    public class BarsController : BarReviewsController
    {
        private readonly IBarsService barsService;
        private readonly IImageService imageService;
        private readonly IWebHostEnvironment webHost;
        private readonly ApplicationDbContext _context;
        private readonly IDestinationsService destinationsService;

        public BarsController(ApplicationDbContext context, IBarsService barsService, IImageService imageService, IWebHostEnvironment webHost,IDestinationsService destinationsService)
        {
            _context = context;
            this.barsService = barsService;
            this.imageService = imageService;
            this.webHost = webHost;
            this.destinationsService = destinationsService;
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
             await this.barsService.CreateAsync(bar/*, webHost.WebRootPath*/);

            return this.RedirectToAction("index");
        }

        //GET: Bars/Update/5
        public IActionResult Update(int id)
        {
            BarUpdateBindingModel bar = this.barsService.GetByIdForUpdateMethod(id);
            IEnumerable<IdNameViewModel> destinations = this.destinationsService.GetAll();
            
            

            bool isBarsNull = bar == null;
            bool areDestinationsEmpty = destinations.Count() == 0;

            if (isBarsNull||areDestinationsEmpty)
            {
                return this.RedirectToAction("index");
            }
            
            ViewBag.Destinations = destinations;
            return this.View(bar);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BarUpdateBindingModel model)
        {

            bool isUpdated = await this.barsService.UpdateAsync(model/*, webHost.WebRootPath*/);
            if (isUpdated == false)
            {
                return this.BadRequest();
            }

            return this.RedirectToAction("index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await this.barsService.DeleteAsync(id);

            return this.RedirectToAction("index");
        }
    }
}
