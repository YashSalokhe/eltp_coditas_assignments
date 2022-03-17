using System.Collections.Generic;
using System.Threading.Tasks;

namespace Assignment_16_16_March_.Services
{
  
        public interface IService<TEntity, in TPk> where TEntity : class
        {
            Task<IEnumerable<TEntity>> GetAsync();
            Task<TEntity> GetAsync(TPk id);
            Task<TEntity> CreateAsync(TEntity T);
            Task<TEntity> UpdateAsync(TPk id, TEntity T);
            Task<TEntity> DeleteAsync(TPk id);
        }
    
}
