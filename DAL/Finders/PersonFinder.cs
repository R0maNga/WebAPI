using BLL.Entities;
using BLL.Finders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders
{
    public class PersonFinder : IPersonFinder
    {
        private readonly DbSet<Person> speakerDbSet;
        public PersonFinder(DbSet<Person> speakerDbSet)
        {
            this.speakerDbSet = speakerDbSet;

        }

        protected IQueryable<Person> AsQueryable()
        {
            return speakerDbSet.AsQueryable();
        }

        public Task<List<Person>> Get()
        {
            return AsQueryable().ToListAsync();
        }
    }
}
