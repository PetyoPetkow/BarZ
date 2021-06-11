namespace BarZ.Areas.Bar_reviews.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using BarZ.Areas.Bar_reviews.Models.Bars.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;
    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Services.Interfaces;
    using BarZ.Data.Models;

    public class BarsController : BarReviewsController
    {
        private readonly IBarsService barsService;
        private readonly IFeaturesService featuresService;
        private readonly IImageService imageService;
        private readonly IDestinationsService destinationsService;
        private readonly IBarsFeaturesService BarsFeaturesService;

        public BarsController(
            IBarsService barsService, 
            IImageService imageService,
            IDestinationsService destinationsService, 
            IFeaturesService featuresService, 
            IBarsFeaturesService barsFeaturesService
            )
        {
            this.barsService = barsService;
            this.imageService = imageService;
            this.destinationsService = destinationsService;
            this.featuresService = featuresService;
            this.BarsFeaturesService = barsFeaturesService;
        }
        
        public IActionResult ShowBarsInDestination(int id)
        {
            IEnumerable<BarViewModel> bars = this.barsService.GetAllBarsInDestination(id);      
                
            return this.View(bars);
        }
        public IActionResult ShowBarsByFeature(int id)
        {
            IEnumerable<BarViewModel> bars = this.barsService.ShowBarsByFeature(id);

            return this.View(bars);
        }
        public IActionResult Search()
        {
            return this.View();
        }
        [HttpPost]
        public IActionResult Search(string SearchPhrase)
        {
            IEnumerable<BarViewModel> bars = this.barsService.SearchForABar(SearchPhrase);
            if (bars.Any())
            {
                return this.View("Index", bars);
            }
            return RedirectToAction("Search");
            //TODO: ADD NOTIFICATION FOR BAR WAS NOT FOUND!
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
            List<Feature> features = this.featuresService.GetAllFeaturesForViewBag().ToList();

            bool areDestinationsEmpty = destinations.Count() == 0;
            if (areDestinationsEmpty)
            {
                return this.RedirectToAction("index");
            }

            ViewBag.Destinations = destinations;
            ViewBag.Features = features;

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
        
            var features = barsService.PopulateSelectedFeaturesData(bar);

            ViewBag.Features = features;
            ViewBag.Destinations = destinations;
            return this.View(bar);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(BarUpdateBindingModel model, string[] selectedFeatures)
        {
            bool isUpdated = await this.barsService.UpdateAsync(model, selectedFeatures);
            if (isUpdated == false)
            {
                return this.BadRequest();
            }
          
            return this.RedirectToAction("index");
        }
        
        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bar = barsService.GetByIdForDeleteMethod(id);

            if (bar == null)
            {
                return NotFound();
            }

            return View(bar);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await this.barsService.DeleteAsync(id);

            return this.RedirectToAction("index");
        }

        public async Task<IActionResult> AddFeatureToABar(int currentBarId, int featureId)
        {
            await this.BarsFeaturesService.AddFeatureToABar(currentBarId, featureId);

            return RedirectToAction("index");
        }
    }
}
