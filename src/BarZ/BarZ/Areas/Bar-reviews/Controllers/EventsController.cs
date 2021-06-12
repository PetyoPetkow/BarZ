namespace BarZ.Areas.Bar_reviews.Controllers
{
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    using BarZ.Services.Interfaces;
    using BarZ.Areas.Bar_reviews.Models.Events.BindingModels;
    using BarZ.Constants;
    using Microsoft.AspNetCore.Authorization;
    using System.Collections.Generic;
    using System.Linq;
    using BarZ.Areas.Bar_reviews.Models.Bars.ViewModels;

    [Area("Bar-reviews")]
    public class EventsController : BarReviewsController
    {
        private readonly IEventsService eventsService;
        private readonly IBarsService barsService;

        public EventsController(IEventsService eventsService, IBarsService barsService)
        {
            this.eventsService = eventsService;
            this.barsService = barsService;
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

        [Authorize]
        public IActionResult Create()
        {
            IEnumerable<BarViewModel> bars = this.barsService.GetAll();

            bool areBarsEmpty = bars.Count() == 0;
            if (areBarsEmpty)
            {
                return this.RedirectToAction("index");
            }

            ViewBag.Bars = bars;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> Create(EventCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                await eventsService.CreateAsync(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [Authorize(Roles = RolesConstants.AdminRoleName)]
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
        [Authorize(Roles = RolesConstants.AdminRoleName)]
        public async Task<IActionResult> UpdateAsync(EventUpdateBindingModel model)
        {
            bool isUpdated = await eventsService.UpdateAsync(model);
            if (isUpdated==false)
            {
                return this.BadRequest();
            }

            return RedirectToAction("Index");
        }

        [Authorize(Roles = RolesConstants.AdminRoleName)]
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
        [Authorize(Roles = RolesConstants.AdminRoleName)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await eventsService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
