namespace BarZ.Areas.Bar_reviews.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using BarZ.Services.Interfaces;
    using BarZ.Areas.Bar_reviews.Models.Features.BindingModels;

    [Area("Bar-reviews")]
    public class FeaturesController : Controller
    {
        private readonly IFeaturesService featuresService;
        public FeaturesController(IFeaturesService featuresService)
        {
            this.featuresService = featuresService;
        }

        public IActionResult Index()
        {
            var features = featuresService.GetAll();

            return View(features);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(FeatureCreateBindingModel feature)
        {
            if (ModelState.IsValid)
            {
                await featuresService.CreateAsync(feature);

                return RedirectToAction("Index");
            }
            return View(feature);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feature = featuresService.GetByIdForUpdateMethod(id);

            if (feature == null)
            {
                return NotFound();
            }
            return View(feature);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(FeatureUpdateBindingModel model)
        {
            var feature =await featuresService.UpdateAsync(model);
            if (feature)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feature = featuresService.GetByIdForDeleteMethod(id);
     
            if (feature == null)
            {
                return NotFound();
            }

            return View(feature);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(FeatureDeleteBindingModel model)
        {
            var feature = await featuresService.DeleteAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
