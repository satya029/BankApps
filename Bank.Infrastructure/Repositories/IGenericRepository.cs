using Bank.Core.Entities;

namespace Bank.Infrastructure.Repositories
{
    public interface IGenericRepository
    { 

    }
    public interface IGenericRepository<TEntity> : IGenericRepository where TEntity : class, IBaseIdentity
    {
        void Create(TEntity entity, bool isUpdate = false);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
    }
}
