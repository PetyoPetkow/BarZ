namespace BarZ.Areas.Bar_reviews.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using BarZ.Areas.Bar_reviews.Models.Destinations.ViewModels;
    using BarZ.Services.Interfaces;
    using BarZ.Areas.Bar_reviews.Models.Destinations.BindingModels;

    public class DestinationsController : BarReviewsController
    {
        private readonly IDestinationsService destinationsService;

        public DestinationsController(IDestinationsService destinationsService)
        {
            this.destinationsService = destinationsService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<IdNameViewModel> destinations = this.destinationsService.GetAll();
            DestinationsViewModel destinationsViewModel = new DestinationsViewModel();

            destinationsViewModel.Destinations = destinations;
           
            return this.View(destinationsViewModel);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var destination = destinationsService.GetByIdForDetailsMethod(id);
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DestinationCreateBindingModel model)
        {
           
            await destinationsService.CreateAsync(model);
           
            return RedirectToAction("index");
        }
        
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

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var destination =destinationsService.GetByIdForDeleteMethod(id);
         
            if (destination == null)
            {
                return NotFound();
            }

            return View(destination);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await destinationsService.DeleteAsync(id);

            return RedirectToAction("Index");
        }
    }
}
