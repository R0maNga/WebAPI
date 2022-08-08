using BLL.Entities;
using BLL.Finders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders
{
    public class SpeakerFinder : ISpeakerFinder
    {
        private readonly DbSet<Speaker> speakerDbSet;

        public SpeakerFinder(DbSet<Speaker> speakerDbSet)
        {
            this.speakerDbSet = speakerDbSet;
        }

        protected IQueryable<Speaker> AsQueryable()
        {
            return speakerDbSet.AsQueryable();
        }
        public Task<List<Speaker>> Get(bool includeEvents = false, bool includePerson = false)
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
