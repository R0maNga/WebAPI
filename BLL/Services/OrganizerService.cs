using BLL.Entities;
using BLL.Finders;
using BLL.Repositories;
using BLL.Services.Interfaces;
using BLL.UnitOfWork;

namespace BLL.Services
{
    public class OrganizerService : IOrganizerService
    {
        private IRepository<Organizer> _organizer;
        private readonly IOrganizerFinder _IOrganizerFinder;
        private IUnitOfWork _unitOfWork;



        public OrganizerService(IUnitOfWork UnitOfWork, IRepository<Organizer> Organizer, IOrganizerFinder IOrganizerFinder)
        {
            _IOrganizerFinder = IOrganizerFinder;
            _unitOfWork = UnitOfWork;
            _organizer = Organizer;

        }


        public Task Create(Organizer organizer)
        {
            _organizer.Create(organizer);
            return _unitOfWork.SaveChanges();
        }

        public Task Delete(Organizer organizer)
        {
            _organizer.Delete(organizer);
            return _unitOfWork.SaveChanges();
        }
        public Task Update(Organizer organizer)
        {
            _organizer.Update(organizer);
            return _unitOfWork.SaveChanges();
        }
        public Task<List<Organizer>> GetAll(bool includeEvents = false, bool includePerson = false)
        {
            return _IOrganizerFinder.Get(includeEvents: includeEvents, includePerson: includePerson);
        }
    }
}
