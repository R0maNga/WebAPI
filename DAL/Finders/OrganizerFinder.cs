using BLL.Entities;
using BLL.Finders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders
{
    public class OrganizerFinder : IOrganizerFinder
    {
        private readonly DbSet<Organizer> organizerDbSet;

        public OrganizerFinder(DbSet<Organizer> organizerDbSet)
        {
            this.organizerDbSet = organizerDbSet;
        }

        protected IQueryable<Organizer> AsQueryable()
        {
            return organizerDbSet.AsQueryable();
        }
        public Task<List<Organizer>> Get(bool includeEvents = false, bool includePerson = false)
        {
            var res = AsQueryable();
            res = includeEvents
                ? res.Include(t => t.Events)
                : res;
            res = includePerson
                ? res.Include(t => t.Person)
                : res;
            return AsQueryable().ToListAsync();
        }
    }
}
