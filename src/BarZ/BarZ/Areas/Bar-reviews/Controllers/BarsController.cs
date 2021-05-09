namespace BarZ.Areas.Bar_reviews.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Data;
    using BarZ.Services.Interfaces;

    public class BarsController : BarReviewsController
    {
        private readonly IBarsService barsService;
        private readonly IImageService imageService;
        private readonly IDestinationsService destinationsService;

        public BarsController(IBarsService barsService, IImageService imageService,IDestinationsService destinationsService)
        {
            this.barsService = barsService;
            this.imageService = imageService;
            this.destinationsService = destinationsService;
        }

        // GET: Bars
        public IActionResult Index()
        {
            IEnumerable<BarViewModel> bars = this.barsService.GetAll();

            return this.View(bars);
        }

        // GET: Bars/Details/5
        public IActionResult Details(int? id)
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
            IEnumerable<IdNameViewModel> destinations = this.destinationsService.GetAll();

            bool areDestinationsEmpty = destinations.Count() == 0;
            if (areDestinationsEmpty)
            {
                return this.RedirectToAction("index");
            }

            ViewBag.Destinations = destinations;

            return this.View();
            
        }

        // POST: Bars/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BarCreateBindingModel bar)
        {
             await this.barsService.CreateAsync(bar);

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

            bool isUpdated = await this.barsService.UpdateAsync(model);
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
