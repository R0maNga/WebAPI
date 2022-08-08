using BLL.Entities;

namespace BLL.Finders
{
    public interface IOrganizerFinder
    {
        public Task<List<Organizer>> Get(bool includeEvents = false, bool includePerson = false);
    }
}
