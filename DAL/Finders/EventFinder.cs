using BLL.Entities;
using BLL.Finders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders
{
    public class EventFinder : IEventFinder
    {
        private readonly DbSet<Event> eventDbSet;
        public EventFinder(DbSet<Event> eventDbSet)
        {
            this.eventDbSet = eventDbSet;

        }

        protected IQueryable<Event> AsQueryable()
        {
            return eventDbSet.AsQueryable();
        }
        public Task<List<Event>> Get(
            bool includePlace = false,
            bool includeSpeaker = false,
            bool includeOrganizer = false)
        {
            var res = AsQueryable();
            res = includePlace
                ? res.Include(t => t.Place)
                : res;
            res = includeSpeaker
                ? res.Include(t => t.Speaker)
                : res;
            res = includeOrganizer
                ? res.Include(t => t.Organizer).ThenInclude(t => t.Person)
                : res;
            return res.ToListAsync();
        }
        public Task<Event?> GetById(int id,
            bool includePlace = false,
            bool includeSpeaker = false,
            bool includeOrganizer = false)
        {
            var res = AsQueryable();
            res = includePlace
                ? res.Include(t => t.Place)
                : res;
            res = includeSpeaker
                ? res.Include(t => t.Speaker).ThenInclude(t => t.Person)
                : res;
            res = includeOrganizer
                ? res.Include(t => t.Organizer).ThenInclude(t => t.Person)
                : res;
            return res.FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
