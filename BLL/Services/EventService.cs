using BLL.Entities;
using BLL.Finders;
using BLL.Repositories;
using BLL.Services.Interfaces;
using BLL.UnitOfWork;

namespace BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _eventRepository;
        private readonly IEventFinder _eventFinder;
        private readonly IUnitOfWork _unitOfWork;

        public EventService(IRepository<Event> eventRepository, IEventFinder eventFinder, IUnitOfWork unitOfWork)
        {
            _eventRepository = eventRepository;
            _eventFinder = eventFinder;
            _unitOfWork = unitOfWork;
        }

        public Task Create(Event entity)
        {
            _eventRepository.Create(entity);
            return _unitOfWork.SaveChanges();
        }

        public Task Update(Event entity)
        {
            
            _eventRepository.Update(entity);
            
            return _unitOfWork.SaveChanges();
        }

        public Task Delete(Event entity)
        {
            _eventRepository.Delete(entity);
            return _unitOfWork.SaveChanges();

        }

        public Task<List<Event>> GetAll(
            bool includePlace = false,
            bool includeOrganizer = false,
            bool includeSpeaker = false)
        {
            return _eventFinder.Get(includePlace: includePlace, includeSpeaker: includeSpeaker, includeOrganizer: includeOrganizer);
        }

        public Task<Event?> GetById(int id,
            bool includePlace = false,
            bool includeSpeaker = false,
            bool includeOrganizer = false)
        {
            return _eventFinder.GetById(id, includePlace: includePlace, includeSpeaker: includeSpeaker, includeOrganizer: includeOrganizer);
        }
    }
}
