using BLL.Entities;
using BLL.Finders;
using BLL.Repositories;
using BLL.Services.Interfaces;
using BLL.UnitOfWork;

namespace BLL.Services
{
    public class SpeakerService : ISpeakerService
    {
        private IRepository<Speaker> _speakerRepository;
        private readonly ISpeakerFinder _speakerFinder;
        private IUnitOfWork _unitOfWork;



        public SpeakerService(IUnitOfWork UnitOfWork, IRepository<Speaker> Speaker, ISpeakerFinder IPlaceFinder)
        {
            _speakerFinder = IPlaceFinder;
            _unitOfWork = UnitOfWork;
            _speakerRepository = Speaker;

        }


        public Task Create(Speaker speaker)
        {
            _speakerRepository.Create(speaker);
            return _unitOfWork.SaveChanges();


        }

        public Task Delete(Speaker speaker)
        {
            _speakerRepository.Delete(speaker);
            return _unitOfWork.SaveChanges();

        }



        public Task Update(Speaker speaker)
        {
            _speakerRepository.Update(speaker);
            return _unitOfWork.SaveChanges();

        }
        public Task<List<Speaker>> GetAll(bool includeEvents = false, bool includePerson = false)
        {
            return _speakerFinder.Get(includeEvents: includeEvents, includePerson: includePerson);
        }
    }
}
