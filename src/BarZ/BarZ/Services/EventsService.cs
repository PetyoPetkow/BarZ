namespace BarZ.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using BarZ.Areas.Bar_reviews.Models.Events.BindingModels;
    using BarZ.Areas.Bar_reviews.Models.Events.ViewModels;
    using BarZ.Data;
    using BarZ.Data.Models;
    using BarZ.Services.Interfaces;

    public class EventsService : IEventsService
    {
        private readonly ApplicationDbContext dbContext;

        public EventsService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<EventViewModel> GetAllFutureEvents()
        {
            IEnumerable<EventViewModel> events = this.dbContext.Events
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    EventName = e.EventName,
                    DateAndTime = e.DateAndTime,
                    Fee = e.Fee,
                    Info = e.Info,
                    Bar = e.Bar,
                })
                .Where(e=>e.DateAndTime > DateTime.UtcNow)
                .OrderBy(e => e.DateAndTime)
                .ToList();

            return events;
        }
        public IEnumerable<EventViewModel> GetAllPastEvents()
        {
            IEnumerable<EventViewModel> events = this.dbContext.Events
                .Select(e => new EventViewModel
                {
                    Id = e.Id,
                    EventName = e.EventName,
                    DateAndTime = e.DateAndTime,
                    Fee = e.Fee,
                    Info = e.Info,
                    Bar = e.Bar,
                })
                .Where(e => e.DateAndTime < DateTime.UtcNow)
                .OrderBy(e => e.DateAndTime)
                .ToList();

            return events;
        }

        public EventUpdateBindingModel GetByIdForUpdateMethod(int? id)
        {
            EventUpdateBindingModel _event = dbContext.Events
                .Select(_event => new EventUpdateBindingModel
                {
                    Id = _event.Id,
                    EventName = _event.EventName,
                    DateAndTime = _event.DateAndTime,
                    Info = _event.Info,
                    Fee = _event.Fee,
                }).Where(e => e.Id == id)
                .FirstOrDefault();

            return _event;
        }

        public EventDeleteBindingModel GetByIdForDeleteMethod(int? id)
        {
            EventDeleteBindingModel _event = dbContext.Events
                .Select(_event => new EventDeleteBindingModel
                {
                    Id = _event.Id,
                    EventName = _event.EventName,
                    DateAndTime = _event.DateAndTime,
                    Info = _event.Info,
                    Bar = _event.Bar,
                }).Where(e => e.Id == id)
                .FirstOrDefault();
            return _event;
        }
        public EventViewModel GetById(int? id)
        {
            EventViewModel _event = dbContext.Events
                .Select(_event => new EventViewModel
                {
                    Id = _event.Id,
                    EventName = _event.EventName,
                    DateAndTime = _event.DateAndTime,
                    Fee = _event.Fee,
                    Info = _event.Info,
                    Bar = _event.Bar,
                })
                .Where(_event => _event.Id == id)
                .FirstOrDefault();

            return _event;
        }

        public async Task<int> CreateAsync(EventCreateBindingModel model)
        {
            Event _event = new Event()
            {
                EventName = model.EventName,
                DateAndTime = model.DateAndTime,
                Fee = model.Fee,
                Info = model.Info,
                BarId = model.BarId,
                
            };
            
            await dbContext.Events.AddAsync(_event);
            await dbContext.SaveChangesAsync();

            return _event.Id;
        }

        public async Task<bool> UpdateAsync(EventUpdateBindingModel model)
        {
            Event _event = GetEventById(model.Id);

            _event.EventName = model.EventName;
            _event.DateAndTime = model.DateAndTime;
            _event.Info = model.Info;
            _event.Fee = model.Fee;
            _event.Bar = model.Bar;

            dbContext.Events.Update(_event);
            await dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Event _event = dbContext.Events
                .Where(_event => _event.Id == id)
                .FirstOrDefault();

            dbContext.Events.Remove(_event);
            await dbContext.SaveChangesAsync();

            return true;
        }

        private Event GetEventById(int id)
        {
            Event _event = this.dbContext.Events
                .Where(l => l.Id == id)
                .SingleOrDefault();

            return _event;
        }
    }
}
