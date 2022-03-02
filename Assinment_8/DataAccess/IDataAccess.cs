using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assinment_8.DataAccess
{
    internal interface IDataAccess<TEntity, in TKey> where TEntity : class
    {
        void GetAllEmployeesByDeptName(TKey id);
        void GetAllEmployeesWithMaxSalByDeptName(TKey id);
        void GetSumSalaryByDeptName(TKey id);
        void GetAllEmployeesByLocation(TKey id);

    }

    internal interface IDataAccessCrud<TEntity, in TPk> where TEntity : class
    {
        IEnumerable<TEntity> GetAllData();
        TEntity Create(TEntity entity);
        TEntity Update(TPk id, TEntity entity);
        TEntity Delete(TPk id);
    }
}
