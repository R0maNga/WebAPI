using BLL.Entities;

namespace BLL.Finders
{
    public interface ISpeakerFinder
    {
        public Task<List<Speaker>> Get(bool includeEvents = false, bool includePerson = false);
    }
}
