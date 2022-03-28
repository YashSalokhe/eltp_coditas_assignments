using System.Collections.Generic;

namespace Shopping_Cart.Services
{
    public interface IService<TEntity, U> where TEntity : class
    {
        IEnumerable<TEntity> Get();
        TEntity Get(U id);
        bool Create(TEntity entity);
        bool Update(U id, TEntity entity);
        bool Delete(U id);
    }
}
