using BLL.Entities;
using BLL.Finders;
using BLL.Repositories;
using BLL.Services.Interfaces;
using BLL.UnitOfWork;

namespace BLL.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IPersonFinder _personFinder;
        private readonly IUnitOfWork _unitOfWork;



        public PersonService(IUnitOfWork UnitOfWork, IRepository<Person> Speaker, IPersonFinder ISpeakerFinder)
        {
            _personFinder = ISpeakerFinder;
            _unitOfWork = UnitOfWork;
            _personRepository = Speaker;

        }
        public Task Create(Person entity)
        {
            _personRepository.Create(entity);
            return _unitOfWork.SaveChanges();
        }

        public Task Delete(Person entity)
        {
            _personRepository.Delete(entity);
            return _unitOfWork.SaveChanges();
        }
        public Task Update(Person entity)
        {
            _personRepository.Update(entity);
            return _unitOfWork.SaveChanges();
        }
        public Task<List<Person>> GetAll()
        {
            return _personFinder.Get();
        }
    }
}
