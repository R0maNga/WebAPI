using BLL.Entities;

namespace BLL.Services.Interfaces
{
    public interface IPlaceService
    {
        Task Create(Place place);
        Task Delete(Place place);
        Task Update(Place place);
        Task<List<Place>> GetAll();
    }
}
