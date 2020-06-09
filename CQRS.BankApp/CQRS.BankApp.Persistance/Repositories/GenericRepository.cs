using CQRS.BankApp.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CQRS.BankApp.Persistance.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class, IMockEntity
    {
        private readonly MockDataContext _mockContext;

        public GenericRepository()
        {
            _mockContext = new MockDataContext();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            if (typeof(TEntity) == typeof(TblBankAccounts))
                return _mockContext.BankAccounts as IQueryable<TEntity>;

            if (typeof(TEntity) == typeof(TblLogins))
                return _mockContext.Logins as IQueryable<TEntity>;

            if (typeof(TEntity) == typeof(TblNotifications))
                return _mockContext.Notifications as IQueryable<TEntity>;

            throw new NotSupportedException("Not supported type. TEntity not found.");
        }

        public virtual TEntity GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public virtual void Create(TEntity entity)
        {
            if (typeof(TEntity) == typeof(TblNotifications))
               (_mockContext.Notifications as List<TblNotifications>).Add(entity as TblNotifications);

            if (typeof(TEntity) == typeof(TblBankAccounts))
                (_mockContext.BankAccounts as List<TblBankAccounts>).Add(entity as TblBankAccounts);

            throw new InvalidCastException("Unable to cast while creating.");
        }

        public virtual void Update(TEntity entity)
        {
            var entityToUpdate = GetById(entity.Id);

            if (entityToUpdate != null)
            {
                if (typeof(TEntity) == typeof(TblBankAccounts))
                    _mockContext.BankAccounts.ToList().Remove(entityToUpdate as TblBankAccounts);

                if (typeof(TEntity) == typeof(TblNotifications))
                    _mockContext.Notifications.ToList().Remove(entityToUpdate as TblNotifications);

                Create(entity);
            }
        }
    }
}
