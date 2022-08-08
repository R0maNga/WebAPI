using BLL.Entities;
using BLL.Finders;
using BLL.Repositories;
using BLL.Services.Interfaces;
using BLL.UnitOfWork;

namespace BLL.Services
{
    public class PlaceService : IPlaceService
    {
        private IRepository<Place> _place;
        private readonly IPlaceFinder _IPlaceFinder;
        private IUnitOfWork _unitOfWork;



        public PlaceService(IUnitOfWork UnitOfWork, IRepository<Place> Place, IPlaceFinder IPlaceFinder)
        {
            _IPlaceFinder = IPlaceFinder;
            _unitOfWork = UnitOfWork;
            _place = Place;

        }


        public Task Create(Place place)
        {
            _place.Create(place);
            return _unitOfWork.SaveChanges();


        }

        public Task Delete(Place place)
        {
            _place.Delete(place);
            return _unitOfWork.SaveChanges();

        }



        public Task Update(Place place)
        {
            _place.Update(place);
            return _unitOfWork.SaveChanges();

        }
        public Task<List<Place>> GetAll()
        {
            return _IPlaceFinder.Get();

        }
    }
}
