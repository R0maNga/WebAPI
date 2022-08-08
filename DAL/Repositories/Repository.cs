using BLL.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbSet<TEntity> _dbSet;
        public Repository(DbSet<TEntity> dbSet)
        {
            _dbSet = dbSet;
        }
        public void Create(TEntity item)
        {
            _dbSet.Add(item);
        }

        public void Delete(TEntity item)
        {
            _dbSet.Remove(item);
        }

        public void Update(TEntity item)
        {
            _dbSet.Update(item);
        }
    }
}
