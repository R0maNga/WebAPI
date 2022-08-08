using BLL.Entities;
using BLL.Finders;
using Microsoft.EntityFrameworkCore;

namespace DAL.Finders
{
    public class PlaceFinder : IPlaceFinder
    {
        private readonly DbSet<Place> placeDbSet;
        public PlaceFinder(DbSet<Place> placeDbSet)
        {
            this.placeDbSet = placeDbSet;

        }

        protected IQueryable<Place> AsQueryable()
        {
            return placeDbSet.AsQueryable();
        }

        public Task<List<Place>> Get()
        {
            return AsQueryable().ToListAsync();
        }
    }
}
