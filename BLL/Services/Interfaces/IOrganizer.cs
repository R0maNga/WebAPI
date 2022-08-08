using BLL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IOrganizerService
    {
        Task Create(Organizer organizer);
        Task Delete(Organizer organizer);
        Task Update(Organizer organizer);
        Task<List<Organizer>> GetAll(bool includeEvents = false, bool includePerson = false);
    }
}
