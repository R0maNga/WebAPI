using BLL.Entities;

namespace BLL.Services.Interfaces
{
    public interface ISpeakerService
    {
        Task Create(Speaker speaker);
        Task Delete(Speaker speaker);
        Task Update(Speaker speaker);
        public Task<List<Speaker>> GetAll(bool includeEvents = false, bool includePerson = false);
    }
}
