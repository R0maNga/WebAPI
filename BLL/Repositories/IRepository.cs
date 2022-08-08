namespace BLL.Repositories
{


    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity item);
        void Delete(TEntity item);
        void Update(TEntity item);
    }

}
