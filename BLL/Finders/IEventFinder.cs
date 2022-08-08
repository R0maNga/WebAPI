using BLL.Entities;

namespace BLL.Finders
{
    public interface IEventFinder
    {
        Task<List<Event>> Get(
            bool includePlace = false,
            bool includeOrganizer = false,
            bool includeSpeaker = false);
        Task<Event?> GetById(int id,
            bool includePlace = false,
            bool includeSpeaker = false,
            bool includeOrganizer = false);
    }
}
