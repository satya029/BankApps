using Bank.Core.Entities;
using System.Diagnostics;
using System.Xml.Linq;

namespace Bank.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IBaseIdentity
    {
        private readonly MockDataContext _mockContext;
    
        public GenericRepository()
        {
            _mockContext = new MockDataContext();
            
        }

        public virtual IEnumerable<TEntity> GetAll()
        {

            if (typeof(TEntity) == typeof(BankAccounts))
                return _mockContext.BankAccounts as IEnumerable<TEntity>;
            else if (typeof(TEntity) == typeof(UserLogins))
                return _mockContext.Logins as IEnumerable<TEntity>;
            else if (typeof(TEntity) == typeof(TblNotifications))
                return _mockContext.Notifications as IEnumerable<TEntity>;
            else if (typeof(TEntity) == typeof(TblInvalidKeys))
                return _mockContext.InvalidKeys as IEnumerable<TEntity>;
            else if (typeof(TEntity) == typeof(TblEvents))
                return _mockContext.Events as IEnumerable<TEntity>;
            else
                throw new NotSupportedException("Not supported type. TEntity not found.");
        }

        public virtual TEntity GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public virtual void Create(TEntity entity, bool isUpdate = false)
        {
            //Autoincrement implementation
            if (!isUpdate)
                entity.Id = GetAll().Count() + 1;

            if (typeof(TEntity) == typeof(TblNotifications))
                (_mockContext.Notifications as List<TblNotifications>).Add(entity as TblNotifications);
            else if (typeof(TEntity) == typeof(BankAccounts))
                (_mockContext.BankAccounts as List<BankAccounts>).Add(entity as BankAccounts);
            else if (typeof(TEntity) == typeof(TblInvalidKeys))
                (_mockContext.InvalidKeys as List<TblInvalidKeys>).Add(entity as TblInvalidKeys);
            else if (typeof(TEntity) == typeof(TblEvents))
                (_mockContext.Events as List<TblEvents>).Add(entity as TblEvents);
            else
                throw new InvalidCastException("Unable to cast while creating.");
        }

        public virtual void Update(TEntity entity)
        {
            var entityToUpdate = GetById(entity.Id);

            if (entityToUpdate != null)
            {
                if (typeof(TEntity) == typeof(BankAccounts))
                    _mockContext.BankAccounts.ToList().Remove(entityToUpdate as BankAccounts);
                else if (typeof(TEntity) == typeof(TblNotifications))
                    _mockContext.Notifications.ToList().Remove(entityToUpdate as TblNotifications);
                else
                    throw new InvalidCastException("Unable to cast while creating.");

                Create(entity, isUpdate: true);
            }
        }
    }
}
