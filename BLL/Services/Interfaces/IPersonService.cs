using BLL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IPersonService
    {
        Task Create(Person speaker);
        Task Delete(Person place);
        Task Update(Person place);
        Task<List<Person>> GetAll();
    }
}
