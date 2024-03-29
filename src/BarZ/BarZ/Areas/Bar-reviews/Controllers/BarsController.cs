﻿namespace BarZ.Areas.Bar_reviews.Controllers
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
    using BarZ.Constants;
    using Microsoft.AspNetCore.Authorization;

    public class BarsController : BarReviewsController
    {
        private readonly IBarsService barsService;
        private readonly IFeaturesService featuresService;
        private readonly IImageService imageService;
        private readonly IDestinationsService destinationsService;

        public BarsController(
            IBarsService barsService, 
            IImageService imageService,
            IDestinationsService destinationsService, 
            IFeaturesService featuresService 
            )
        {
            this.barsService = barsService;
            this.imageService = imageService;
            this.destinationsService = destinationsService;
            this.featuresService = featuresService;
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
            if (this.barsService.SearchForABar(SearchPhrase)!=null)
            {
                IEnumerable<BarViewModel> bars = this.barsService.SearchForABar(SearchPhrase);
                if (bars.Any())
                {
                    return this.View("Index", bars);
                }
            }

            return RedirectToAction("Search");
            //TODO: ADD NOTIFICATION FOR BAR WAS NOT FOUND!
            //UPDATE: NOT ENOUGH TIME TO DO THAT...
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
        [Authorize]
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
        [Authorize]
        public async Task<IActionResult> Create(BarCreateBindingModel bar)
        {
             await this.barsService.CreateAsync(bar);

            return this.RedirectToAction("index");
        }

        //GET: Bars/Update/5
        [Authorize(Roles = RolesConstants.AdminRoleName)]
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
        [Authorize(Roles = RolesConstants.AdminRoleName)]
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
        [Authorize(Roles = RolesConstants.AdminRoleName)]
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
        [Authorize(Roles = RolesConstants.AdminRoleName)]
        public async Task<IActionResult> Delete(int id)
        {
            await this.barsService.DeleteAsync(id);

            return this.RedirectToAction("index");
        }
    }
}
