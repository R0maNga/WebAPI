using BLL.Entities;

namespace BLL.Finders
{
    public interface IPersonFinder
    {
        public Task<List<Person>> Get();
    }
}
