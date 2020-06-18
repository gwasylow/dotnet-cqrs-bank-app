using System.Collections.Generic;

namespace CQRS.BankApp.Persistance.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class, IMockEntity
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
    }
}
