namespace BLL.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveChanges();
    }
}
