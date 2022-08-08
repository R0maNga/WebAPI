using BLL.Entities;
using BLL.UnitOfWork;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly TestContext _dbcontext;
        public Task<int> SaveChanges()
        {
            Event e1;
            /*e1= _dbcontext.Events.FirstOrDefault();
            _dbcontext.Entry(e1).State = Microsoft.EntityFrameworkCore.EntityState.Modified;*/
            return _dbcontext.SaveChangesAsync();
        }
        public UnitOfWork(TestContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
    }
}
