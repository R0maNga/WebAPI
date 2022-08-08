using BLL.Entities;

namespace BLL.Finders
{
    public interface IPlaceFinder
    {
        public Task<List<Place>> Get();
    }
}
