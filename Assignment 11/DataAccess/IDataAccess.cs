using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_11.DataAccess
{
    internal interface IDataAccess<TEntity, in TPk> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetEmpDataAsync();
             Task Create(TEntity entity);
        Task<int> Delete(TPk id);
        Task Update(TEntity entity, TPk id);
    }
}
