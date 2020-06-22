using System.Collections.Generic;

namespace CQRS.BankApp.Persistance.Repositories
{
    public interface IGenericRepository
    { 

    }
    public interface IGenericRepository<TEntity> : IGenericRepository where TEntity : class, IMockEntity
    {
        void Create(TEntity entity);
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        void Update(TEntity entity);
    }
}
