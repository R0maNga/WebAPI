using BLL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IEventService
    {
        Task Create(Event event_);
        Task Update(Event event_);
        Task Delete(Event event_);
        public Task<List<Event>> GetAll(
            bool includePlace = false,
            bool includeOrganizer = false,
            bool includeSpeaker = false);
        public Task<Event?> GetById(int id,
            bool includePlace = false,
            bool includeSpeaker = false,
            bool includeOrganizer = false);
    }

}
