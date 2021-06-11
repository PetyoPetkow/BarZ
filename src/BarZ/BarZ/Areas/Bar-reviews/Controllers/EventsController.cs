namespace BarZ.Areas.Bar_reviews.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using BarZ.Services.Interfaces;
    using BarZ.Areas.Bar_reviews.Models.Events.BindingModels;

    [Area("Bar-reviews")]
    public class EventsController : Controller
    {
        private readonly IEventsService eventsService;

        public EventsController(IEventsService eventsService)
        {
            this.eventsService = eventsService;
        }

        public IActionResult Index()
        {
            var events = this.eventsService.GetAll();
            return View(events);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _event = eventsService.GetById(id);
                
            if (_event == null)
            {
                return NotFound();
            }

            return View(_event);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                await eventsService.CreateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        public IActionResult Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _event = eventsService.GetByIdForUpdateMethod(id);

            if (_event == null)
            {
                return NotFound();
            }
            return View(_event);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateAsync(EventUpdateBindingModel model)
        {
            bool isUpdated = await eventsService.UpdateAsync(model);
            if (isUpdated==false)
            {
                return this.BadRequest();
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var _event = eventsService.GetByIdForDeleteMethod(id);

            if (_event == null)
            {
                return NotFound();
            }

            return View(_event);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await eventsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
